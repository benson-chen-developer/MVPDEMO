using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using YourNamespace.Models;
using Microsoft.Extensions.Configuration;
using MVC.Models;

public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        using var db = new SqlConnection(_connectionString);
        try
        {
            db.Open(); // Try opening the connection
            Console.WriteLine("✅ Successfully connected to the database.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Database connection failed: {ex.Message}");
        }
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);

    // 📌 Get All Users
    public IEnumerable<User> GetAllUsers()
    {
        using var db = Connection;
        string sql = "SELECT * FROM Users";
        return db.Query<User>(sql);
    }

    // 📌 Get User by ID
    public User GetUserById(int id)
    {
        using var db = Connection;
        string sql = "SELECT * FROM Users WHERE Id = @Id";
        return db.QuerySingleOrDefault<User>(sql, new { Id = id });
    }

    // 📌 Insert User (POST)
    public int AddUser(User user)
    {
        using var db = Connection;
        string sql = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";
        return db.Execute(sql, user);
    }

    public IEnumerable<Product> GetProducts(int userId)
    {
        using var db = Connection;
        string sql = "SELECT * FROM Products WHERE UserId = @UserId";
        return db.Query<Product>(sql, new { UserId = userId });
    }

}
