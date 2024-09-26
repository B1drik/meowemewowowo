using System;

class Program
{
    static void Main(string[] args)
    {
        var servers = Servers.Instance;

        // Добавление серверов 
        Console.WriteLine(servers.AddServer("http://example.com"));   // True 
        Console.WriteLine(servers.AddServer("https://example.com"));  // True 
        Console.WriteLine(servers.AddServer("http://example.com"));   // False (дубликат) 
        Console.WriteLine(servers.AddServer("ftp://example.com"));    // False (не начинается с http или https) 

        // Получение списков серверов 
        Console.WriteLine("HTTP servers: " + string.Join(", ", servers.GetHttpServers()));   // [http://example.com] 
        Console.WriteLine("HTTPS servers: " + string.Join(", ", servers.GetHttpsServers())); // [https://example.com] 
    }
}