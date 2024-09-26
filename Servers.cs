using System;
using System.Collections.Generic;
using System.Linq;

public class Servers
{
    private static readonly Lazy<Servers> _instance = new Lazy<Servers>(() => new Servers());
    private readonly HashSet<string> _servers;
    private readonly object _lock = new object(); 

    
    private Servers()
    {
        _servers = new HashSet<string>();
    }

    public static Servers Instance => _instance.Value;

    public bool AddServer(string serverAddress)
    {
        lock (_lock) 
        {
            
            if ((serverAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                 serverAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) &&
                _servers.Add(serverAddress)) 
            {
                return true;
            }
            return false;
        }
    }

    public List<string> GetHttpServers()
    {
        lock (_lock) 
        {
            return _servers.Where(server => server.StartsWith("http://", StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }

    public List<string> GetHttpsServers()
    {
        lock (_lock) 
        {
            return _servers.Where(server => server.StartsWith("https://", StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}