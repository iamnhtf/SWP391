using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;
using TestServer.DTOs;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext db;

        public CustomerController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await db.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await db.Customers.FindAsync(id);
            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (await db.Customers.AnyAsync(c => c.Id == customer.Id))
            {
                return Conflict($"Customer with ID {customer.Id} already exists.");
            }

            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Customer updatedCustomer)
        {
            var existingCustomer = await db.Customers.FindAsync(id);
            if (existingCustomer == null)
                return NotFound($"Customer with ID {id} not found.");

            if (updatedCustomer.Name != null)
                existingCustomer.Name = updatedCustomer.Name;
            if (updatedCustomer.Email != null)
                existingCustomer.Email = updatedCustomer.Email;
            if (updatedCustomer.PhoneNumber != null)
                existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            if (updatedCustomer.Address != null)
                existingCustomer.Address = updatedCustomer.Address;

            await db.SaveChangesAsync();
            return Ok(existingCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await db.Customers.FindAsync(id);
            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");

            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return Ok($"Customer with ID {id} deleted.");
        }

        // GET api/customer/{id}/status
        [HttpGet("{id}/status")]
        public async Task<IActionResult> GetStatus(string id)
        {
            var customer = await db.Customers.FindAsync(id);
            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");

            return Ok(new { Status = customer.Status.ToString() });
        }

        // PUT api/customer/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(string id, [FromBody] CustomerStatusUpdateDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Status))
                return BadRequest(new { Success = false, Message = "Status is required." });

            var customer = await db.Customers.FindAsync(id);
            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");

            // Try parse enum (case-insensitive)
            if (!System.Enum.TryParse<TestServer.Models.Customer.CustomerStatus>(dto.Status, true, out var parsed))
            {
                return BadRequest(new { Success = false, Message = "Invalid status value." });
            }

            customer.Status = parsed;
            await db.SaveChangesAsync();

            return Ok(new { Success = true, Status = customer.Status.ToString() });
        }
    }
}
