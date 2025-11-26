using Microsoft.AspNetCore.Mvc;
using TestServer.Data;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly AppDbContext db;

        public PackageController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult GetPackages()
        {
            var packages = db.Packages.ToList();
            return Ok(packages);
        }

        //Find by current user's active package subscription
        [HttpGet("current/{uid}")]
        public IActionResult GetCurrentUserPackage(string uid)
        {
            var subscription = db.PackageSubscriptions
                .Where(ps => ps.UserId == uid && ps.EndDate > DateTime.UtcNow)
                .OrderByDescending(ps => ps.EndDate)
                .FirstOrDefault();

            if (subscription == null)
            {
                return Ok(new Dto.UserPackageDto()
                {
                    Id = 0,
                    UserId = uid,
                    PriceAtPurchase = 0,
                    DiscountPercentAtPurchase = 0,
                    ReservationMinutesAtPurchase = 60
                });
            }

            var userPackageDto = new Dto.UserPackageDto
            {
                Id = subscription.Id,
                UserId = subscription.UserId,
                PriceAtPurchase = subscription.PriceAtPurchase,
                DiscountPercentAtPurchase = subscription.DiscountPercentAtPurchase,
                ReservationMinutesAtPurchase = subscription.ReservationMinutesAtPurchase,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate
            };

            return Ok(userPackageDto);
        }

        [HttpPost("buy/{uid}/{pid}")]
        public IActionResult BuyPackage(string uid, int pid)
        {
            var package = db.Packages.Find(pid);
            if (package == null || !package.IsActive)
            {
                return NotFound("Package not found or inactive.");
            }

            if (db.PackageSubscriptions.Any(ps => ps.UserId == uid && ps.EndDate > DateTime.UtcNow))
            {
                db.PackageSubscriptions.RemoveRange(
                    db.PackageSubscriptions.Where(ps => ps.UserId == uid && ps.EndDate > DateTime.UtcNow)
                );
            }

            var startDate = DateTime.UtcNow;
            var endDate = startDate.AddMonths(1);

            var subscription = new Models.PackageSubscription
            {
                UserId = uid,
                PackageId = pid,
                PriceAtPurchase = package.MonthlyPrice,
                DiscountPercentAtPurchase = package.DiscountPercent,
                ReservationMinutesAtPurchase = package.ReservationTime,
                StartDate = startDate,
                EndDate = endDate
            };

            db.PackageSubscriptions.Add(subscription);
            db.SaveChanges();

            return Ok(new Dto.UserPackageDto
            {
                Id = subscription.Id,
                UserId = subscription.UserId,
                PriceAtPurchase = subscription.PriceAtPurchase,
                DiscountPercentAtPurchase = subscription.DiscountPercentAtPurchase,
                ReservationMinutesAtPurchase = subscription.ReservationMinutesAtPurchase,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate
            });
        }
    }
}