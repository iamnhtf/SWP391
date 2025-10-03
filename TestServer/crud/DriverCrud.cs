using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;

namespace TestServer.Crud;

public class DriverCrud
{
    private readonly AppDbContext _context;

    public DriverCrud(AppDbContext context)
    {
        _context = context;
    }

    // Create Driver
    public async Task<Driver> CreateDriver(Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
        return driver;
    }

    // Get Driver by ID
    public async Task<Driver?> GetDriver(int id)
    {
        return await _context.Drivers
            .Include(d => d.AccountPackage)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    // Update Driver
    public async Task<Driver?> UpdateDriver(int id, Driver updatedDriver)
    {
        var existingDriver = await _context.Drivers.FindAsync(id);
        if (existingDriver == null)
        {
            return null;
        }

        existingDriver.Name = updatedDriver.Name;
        existingDriver.LicenseNumber = updatedDriver.LicenseNumber;
        existingDriver.PhoneNumber = updatedDriver.PhoneNumber;
        existingDriver.Car = updatedDriver.Car;
        existingDriver.TotalSpend = updatedDriver.TotalSpend;
        existingDriver.AccountPackageId = updatedDriver.AccountPackageId;

        await _context.SaveChangesAsync();
        return existingDriver;
    }

    // Delete Driver
    public async Task<bool> DeleteDriver(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null)
        {
            return false;
        }

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        return true;
    }

    // Get All Drivers
    public async Task<List<Driver>> GetAllDrivers()
    {
        return await _context.Drivers
            .Include(d => d.AccountPackage)
            .ToListAsync();
    }
}