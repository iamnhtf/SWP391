using System;
using System.Threading;
using System.Threading.Tasks;
using Firebase.Database;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using TestServer.Hubs;
using Firebase.Database.Query;
using TestServer.Controllers;

namespace TestServer.Services
{
    public class FirebaseListenerService : BackgroundService
    {
        private readonly ILogger<FirebaseListenerService> _logger;
        private readonly FirebaseClient _firebaseClient;
        private readonly IHubContext<UnityHub> _hubContext; 
        private IDisposable _listener;
        private readonly ConcurrentDictionary<string, string> _lastStatuses = new();

        public FirebaseListenerService(
            ILogger<FirebaseListenerService> logger,
            FirebaseClient firebaseClient,
            IHubContext<UnityHub> hubContext)
        {
            _logger = logger;
            _firebaseClient = firebaseClient;
            _hubContext = hubContext;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Firebase Listener Service starting...");

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

                        if (!_lastStatuses.TryGetValue(portId, out var lastStatus) ||
                            chargingCommand.status != lastStatus)
                        {
                            _lastStatuses[portId] = chargingCommand.status;

                            if (lastStatus != null)
                                _logger.LogInformation($"[Status Changed] {portId} -> {chargingCommand.status}");

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
                                    _logger.LogInformation($"Start charging vehicle {chargingCommand.vehicle}");
                                    break;

                                case "full":
                                    await _hubContext.Clients.All.SendAsync("FullCharge", JsonSerializer.Serialize(new
                                    {
                                        vehicleId = chargingCommand.vehicle
                                    }));
                                    _logger.LogInformation($"Full charge event triggered for {portId}");
                                    break;

                                case "stop":
                                    await _hubContext.Clients.All.SendAsync("StopCharge", JsonSerializer.Serialize(new
                                    {
                                        vehicleId = chargingCommand.vehicle
                                    }));
                                    _logger.LogInformation($"Stop charge event triggered for {portId}");
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error parsing Firebase data: {ex.Message}");
                    }
                });

            _logger.LogInformation("Firebase Listener Service started successfully!");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _listener?.Dispose();
            _logger.LogInformation("Firebase Listener Service stopped.");
            return base.StopAsync(cancellationToken);
        }
    }
}