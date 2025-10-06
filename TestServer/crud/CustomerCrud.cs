using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;

namespace TestServer.Crud;

public class CustomerCrud
{
    private readonly AppDbContext _context;

    public CustomerCrud(AppDbContext context)
    {
        _context = context;
    }

    // Create Customer
    public async Task<Customer> CreateCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    // Update Customer
    public async Task<Customer?> UpdateCustomer(int id, Customer updatedCustomer)
    {
        var existingCustomer = await _context.Customers.FindAsync(id);
        if (existingCustomer == null)
        {
            return null;
        }

        existingCustomer.Name = updatedCustomer.Name;
        existingCustomer.Email = updatedCustomer.Email;
        existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
        existingCustomer.Address = updatedCustomer.Address;

        await _context.SaveChangesAsync();
        return existingCustomer;
    }

    // Delete Customer
    public async Task<bool> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return false;
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }

    
}