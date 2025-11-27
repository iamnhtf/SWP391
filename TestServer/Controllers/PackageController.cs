using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cms;
using TestServer.Data;
using TestServer.Utils;

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
            var subscription = db
                .PackageSubscriptions.Where(ps => ps.UserId == uid && ps.EndDate > TimeUtil.VNNow())
                .OrderByDescending(ps => ps.EndDate)
                .FirstOrDefault();

            if (subscription == null)
            {
                return Ok(
                    new Dto.UserPackageDto()
                    {
                        Id = 0,
                        UserId = uid,
                        PriceAtPurchase = 0,
                        DiscountPercentAtPurchase = 0,
                        ReservationMinutesAtPurchase = 60,
                    }
                );
            }

            var userPackageDto = new Dto.UserPackageDto
            {
                Id = subscription.Id,
                UserId = subscription.UserId,
                PriceAtPurchase = subscription.PriceAtPurchase,
                DiscountPercentAtPurchase = subscription.DiscountPercentAtPurchase,
                ReservationMinutesAtPurchase = subscription.ReservationMinutesAtPurchase,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
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

            if (db.PackageSubscriptions.Any(ps => ps.UserId == uid && ps.EndDate > TimeUtil.VNNow()))
            {
                db.PackageSubscriptions.RemoveRange(
                    db.PackageSubscriptions.Where(ps =>
                        ps.UserId == uid && ps.EndDate > TimeUtil.VNNow()
                    )
                );
            }

            var startDate = TimeUtil.VNNow();
            var endDate = startDate.AddMonths(1);

            var subscription = new Models.PackageSubscription
            {
                UserId = uid,
                PackageId = pid,
                PriceAtPurchase = package.MonthlyPrice,
                DiscountPercentAtPurchase = package.DiscountPercent,
                ReservationMinutesAtPurchase = package.ReservationTime,
                StartDate = startDate,
                EndDate = endDate,
            };

            db.PackageSubscriptions.Add(subscription);
            db.SaveChanges();

            return Ok(
                new Dto.UserPackageDto
                {
                    Id = subscription.Id,
                    UserId = subscription.UserId,
                    PriceAtPurchase = subscription.PriceAtPurchase,
                    DiscountPercentAtPurchase = subscription.DiscountPercentAtPurchase,
                    ReservationMinutesAtPurchase = subscription.ReservationMinutesAtPurchase,
                    StartDate = subscription.StartDate,
                    EndDate = subscription.EndDate,
                }
            );
        }

        [HttpPost]
        public IActionResult CreatePackage([FromBody] Models.Package input)
        {
            if (input == null)
                return BadRequest("Package data is required.");

            var pkg = new Models.Package
            {
                Name = input.Name,
                Description = input.Description,
                MonthlyPrice = input.MonthlyPrice,
                DiscountPercent = input.DiscountPercent,
                ReservationTime = input.ReservationTime,
                IsActive = input.IsActive,
            };

            db.Packages.Add(pkg);
            db.SaveChanges();

            return Ok(pkg);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePackage(int id, [FromBody] Models.Package input)
        {
            if (input == null)
                return BadRequest("Package data is required.");

            var pkg = db.Packages.Find(id);
            if (pkg == null)
                return NotFound("Package not found.");

            // Cập nhật các trường thường dùng (bạn có thể thêm/bớt tùy model)
            pkg.Name = input.Name;
            pkg.Description = input.Description;
            pkg.MonthlyPrice = input.MonthlyPrice;
            pkg.DiscountPercent = input.DiscountPercent;
            pkg.ReservationTime = input.ReservationTime;
            pkg.IsActive = input.IsActive;

            db.SaveChanges();

            return Ok(pkg);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePackage(int id)
        {
            var pkg = db.Packages.Find(id);
            if (pkg == null)
                return NotFound("Package not found.");

            // --- Hard delete ---
            db.Packages.Remove(pkg);
            db.SaveChanges();
            return Ok("Package deleted.");
        }
    }
}
