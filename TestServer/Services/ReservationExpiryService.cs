using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Utils;

namespace TestServer.Services
{
    public class ReservationExpiryService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<ReservationExpiryService> _logger;

    public ReservationExpiryService(IServiceScopeFactory scopeFactory, ILogger<ReservationExpiryService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var now = TimeUtil.VNNow();

                var expiredReservations = await db.Reservations
                    .Where(r => r.ExpireAt <= now)
                    .ToListAsync();

                foreach (var reservation in expiredReservations)
                {
                    db.Reservations.Remove(reservation);
                }

                await db.SaveChangesAsync();

                _logger.LogInformation($"Auto-expired {expiredReservations.Count} reservations.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ReservationExpiryService");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}

}