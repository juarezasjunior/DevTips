// Existing class (incompatible with client)
public class EuropeanSocket
{
    public void ConnectEuropeanPlug()
    {
        Console.WriteLine("European plug connected to European socket.");
    }
}

// Client's interface
public interface ISocket
{
    void Connect();
}

// Adapter that makes EuropeanSocket compatible with ISocket
public class SocketAdapter : ISocket
{
    private EuropeanSocket _europeanSocket;

    public SocketAdapter(EuropeanSocket europeanSocket)
    {
        _europeanSocket = europeanSocket;
    }

    public void Connect()
    {
        // Adapting the call
        _europeanSocket.ConnectEuropeanPlug();
    }
}

// Client using the ISocket interface
class Program
{
    static void Main(string[] args)
    {
        // Client needs a socket compatible with ISocket
        ISocket socket = new SocketAdapter(new EuropeanSocket());
        socket.Connect();  // Output: European plug connected to European socket.
    }
}