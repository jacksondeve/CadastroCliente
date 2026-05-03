using System;

public class AppConnection
{
    public string ConnectionString { get; set; }

    public AppConnection(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection");

        Console.WriteLine("CONN STRING: " + ConnectionString);
    }
}
