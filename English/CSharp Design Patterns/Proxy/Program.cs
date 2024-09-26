// Interface that defines image operations
public interface IImage
{
    void Display();
}

// Class representing the real image, which is "heavy" to load
public class RealImage : IImage
{
    private string _filePath;

    public RealImage(string filePath)
    {
        _filePath = filePath;
        LoadImage();
    }

    private void LoadImage()
    {
        Console.WriteLine($"Loading image from file {_filePath}...");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image {_filePath}.");
    }
}

// Proxy class that controls access to the RealImage
public class ProxyImage : IImage
{
    private RealImage _realImage;
    private string _filePath;

    public ProxyImage(string filePath)
    {
        _filePath = filePath;
    }

    public void Display()
    {
        // Load the real image only when needed
        if (_realImage == null)
        {
            _realImage = new RealImage(_filePath);
        }
        _realImage.Display();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a proxy image
        IImage image = new ProxyImage("photo.jpg");

        // The real image will only be loaded when it's actually displayed
        Console.WriteLine("Image created, but not loaded yet.");
        image.Display();  // Loading and displaying the real image
        image.Display();  // The image is already loaded, so it just displays
    }
}