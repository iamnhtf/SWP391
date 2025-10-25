using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirebaseController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://ev-charging-station-swp-default-rtdb.firebaseio.com/";

        public FirebaseController()
        {
            _client = new HttpClient();
        }

        [HttpPost("write")]
        public async Task<IActionResult> WriteData()
        {
            var data = new
            {
                name = "Nguyen Xuan Thinh",
                score = 100,
                time = DateTime.UtcNow.ToString("u")
            };

            var response = await _client.PutAsJsonAsync(_baseUrl + "users/thinh.json", data);

            if (response.IsSuccessStatusCode)
                return Ok(new { message = "Data written successfully!" });
            else
                return BadRequest(new { message = "Failed to write data." });
        }

        [HttpGet("read")]
        public async Task<IActionResult> ReadData()
        {
            var response = await _client.GetAsync(_baseUrl + "users/thinh.json");

            if (!response.IsSuccessStatusCode)
                return BadRequest(new { message = "Failed to read data." });

            var content = await response.Content.ReadAsStringAsync();

            var json = System.Text.Json.JsonSerializer.Deserialize<object>(content);
            return Ok(json);
        }
    }
}