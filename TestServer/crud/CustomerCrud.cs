using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;

namespace TestServer.Crud
{
    public class CustomerCrud
    {
        private readonly AppDbContext _context;

        public CustomerCrud(AppDbContext context)
        {
            _context = context;
        }

        // Get All Customers
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // Get Customer by ID
        public async Task<Customer?> GetCustomerById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await _context.Customers.FindAsync(id);
        }

        // Create Customer
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            // Nếu chưa có Id thì tự tạo một Guid dạng chuỗi
            if (string.IsNullOrWhiteSpace(customer.Id))
                customer.Id = Guid.NewGuid().ToString();

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        // Update Customer
        public async Task<Customer?> UpdateCustomer(string id, Customer updatedCustomer)
        {
            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null)
                return null;

            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            existingCustomer.Address = updatedCustomer.Address;

            await _context.SaveChangesAsync();
            return existingCustomer;
        }

        // Delete Customer
        public async Task<bool> DeleteCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
