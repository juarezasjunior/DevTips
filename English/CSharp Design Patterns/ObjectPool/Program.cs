// Example class to be managed by the Object Pool
public class Connection
{
    public string Id { get; set; }

    public Connection(string id)
    {
        Id = id;
        Console.WriteLine($"Connection {Id} created.");
    }

    public void Connect()
    {
        Console.WriteLine($"Connection {Id} connected.");
    }

    public void Disconnect()
    {
        Console.WriteLine($"Connection {Id} disconnected.");
    }
}

// Object Pool class to manage connections
public class ConnectionPool
{
    private List<Connection> _available = new List<Connection>();
    private List<Connection> _inUse = new List<Connection>();

    public Connection GetConnection()
    {
        Connection connection;

        if (_available.Count > 0)
        {
            connection = _available[0];
            _available.RemoveAt(0);
            Console.WriteLine($"Connection {connection.Id} reused.");
        }
        else
        {
            connection = new Connection(Guid.NewGuid().ToString());
        }

        _inUse.Add(connection);
        return connection;
    }

    public void ReleaseConnection(Connection connection)
    {
        _inUse.Remove(connection);
        _available.Add(connection);
        Console.WriteLine($"Connection {connection.Id} released and returned to pool.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConnectionPool pool = new ConnectionPool();

        // Get and use connections
        Connection connection1 = pool.GetConnection();
        connection1.Connect();

        Connection connection2 = pool.GetConnection();
        connection2.Connect();

        // Release connections back to the pool
        connection1.Disconnect();
        pool.ReleaseConnection(connection1);

        Connection connection3 = pool.GetConnection();  // Reusing released connection
        connection3.Connect();

        connection2.Disconnect();
        pool.ReleaseConnection(connection2);
    }
}