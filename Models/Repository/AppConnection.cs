using Npgsql;
using System;
using System.Collections;

public class AppConnection
{
    private readonly string _connectionString;

    public AppConnection(IConfiguration configuration)
    {
        // 🔍 DEBUG - lista todas variáveis de ambiente
        foreach (DictionaryEntry env in Environment.GetEnvironmentVariables())
        {
            Console.WriteLine($"{env.Key} = {env.Value}");
        }
        _connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

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