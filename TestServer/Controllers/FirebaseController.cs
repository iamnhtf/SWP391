using System.Collections.Concurrent;
using System.Text.Json;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TestServer.Hubs;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirebaseController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://ev-charging-station-swp-default-rtdb.firebaseio.com/";
        private readonly IHubContext<UnityHub> _hubContext;
        private readonly FirebaseClient _firebaseClient;
        private static IDisposable _listener;

        public FirebaseController(IHubContext<UnityHub> hubContext)
        {
            _client = new HttpClient();
            _firebaseClient = new FirebaseClient(_baseUrl);
            _hubContext = hubContext;
        }

        [HttpPost("send/{portId}")]
        public async Task<IActionResult> SendData(string portId, [FromBody] object portData)
        {
            if (string.IsNullOrEmpty(portId))
                return BadRequest(new { message = "Missing portId parameter." });

            if (portData == null)
                return BadRequest(new { message = "Missing portData in request body." });

            string portNode = $"Port {portId.Replace(".", "_")}";

            var portDataUrl = $"{_baseUrl}sessions/{portNode}/portData.json";
            var response1 = await _client.PutAsJsonAsync(portDataUrl, portData);

            var statusUrl = $"{_baseUrl}sessions/{portNode}/chargingCommand/status.json";
            var response2 = await _client.PutAsJsonAsync(statusUrl, "waiting");

            if (response1.IsSuccessStatusCode && response2.IsSuccessStatusCode)
            {
                return Ok(new
                {
                    message = "Upload thành công!",
                    time = DateTime.UtcNow.ToString("u")
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "Lỗi upload dữ liệu.",
                    portDataStatus = response1.StatusCode.ToString(),
                    chargingStatus = response2.StatusCode.ToString()
                });
            }
        }

        [HttpGet("read")]
        public async Task<IActionResult> ReadData()
        {
            var response = await _client.GetAsync(_baseUrl + "users/thinh.json");

            if (!response.IsSuccessStatusCode)
                return BadRequest(new { message = "Failed to read data." });

            var content = await response.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<object>(content);
            return Ok(json);
        }

        [HttpGet("listen")]
        public IActionResult Listen()
        {
            if (_listener != null)
                return Ok("Already listening.");

            ConcurrentDictionary<string, string> lastStatuses = new();

            _listener = _firebaseClient
            .Child("sessions")
            .AsObservable<object>()
            .Subscribe(async snapshot =>
            {
                if (snapshot.Object == null || snapshot.Key == null)
                    return;

                try
                {
                    string portId = snapshot.Key;

                    var chargingCommand = await _firebaseClient
                        .Child("sessions")
                        .Child(portId)
                        .Child("chargingCommand")
                        .OnceSingleAsync<ChargingCommand>();

                    if (chargingCommand == null)
                        return;

                    var json = JsonSerializer.Serialize(chargingCommand);
                    //Console.WriteLine($"[Firebase Update] {portId}: {json}");

                    if (!lastStatuses.TryGetValue(portId, out var lastStatus) || chargingCommand.status != lastStatus)
                    {
                        lastStatuses[portId] = chargingCommand.status;
                        if (lastStatus != null)
                            Console.WriteLine($"[Status Changed] {portId} -> {chargingCommand.status}");

                        switch (chargingCommand.status)
                        {
                            case "start":
                                float currentCapacity = (100 - chargingCommand.battery) / 100f * chargingCommand.maxBattery;
                                await _hubContext.Clients.All.SendAsync("StartCharge", JsonSerializer.Serialize(new
                                {
                                    vehicleId = chargingCommand.vehicle,
                                    battery = chargingCommand.battery,
                                    maxBattery = chargingCommand.maxBattery,
                                    currentCapacity
                                }));
                                Console.WriteLine($"Start charging vehicle {chargingCommand.vehicle}");
                                break;

                            case "full":
                                await _hubContext.Clients.All.SendAsync("FullCharge", JsonSerializer.Serialize(new
                                {
                                    vehicleId = chargingCommand.vehicle
                                }));
                                Console.WriteLine("Full charge event triggered.");
                                break;

                            case "stop":
                                await _hubContext.Clients.All.SendAsync("StopCharge", JsonSerializer.Serialize(new
                                {
                                    vehicleId = chargingCommand.vehicle
                                }));
                                Console.WriteLine("Stop charge event triggered.");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error parsing Firebase data: " + ex.Message);
                }
            });

            return Ok("Listening for Firebase changes...");
        }
    }
    
    public class ChargingCommand
    {
        public int battery { get; set; }
        public int maxBattery { get; set; }
        public string status { get; set; }
        public int vehicle { get; set; }
    }
}