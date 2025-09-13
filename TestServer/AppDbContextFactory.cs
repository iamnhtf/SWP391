using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using TestServer.Data; 
using MySql.EntityFrameworkCore;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        string basePath = Directory.GetCurrentDirectory();
        while (!File.Exists(Path.Combine(basePath, "appsettings.json")))
        {
            DirectoryInfo parentDir = Directory.GetParent(basePath);
            if (parentDir == null)
            {
                throw new DirectoryNotFoundException("Could not find appsettings.json. Ensure you are running the command from the project root directory.");
            }
            basePath = parentDir.FullName;
        }

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath) // Đặt base path là thư mục project tìm được
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables() // Lấy thêm biến môi trường nếu có
            .Build();

        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found. Ensure it is configured in appsettings.json or environment variables.");
        }

        builder.UseMySQL(connectionString);

        return new AppDbContext(builder.Options);
    }
}