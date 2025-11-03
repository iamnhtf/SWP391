using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;

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

            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
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
    }
}
