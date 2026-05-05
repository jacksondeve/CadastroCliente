using System;
using Npgsql;

public class AppConnection
{
    private readonly string _connectionString;

    public AppConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");

        Console.WriteLine("CONN STRING: " + _connectionString);

        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new Exception("Connection string não encontrada!");
        }
    }

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}