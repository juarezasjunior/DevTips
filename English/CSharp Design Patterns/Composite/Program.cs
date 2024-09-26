// Base component
public interface IComponent
{
    void Display();
}

// Leaf object (a file, for example)
public class File : IComponent
{
    private string _name;

    public File(string name)
    {
        _name = name;
    }

    public void Display()
    {
        Console.WriteLine($"File: {_name}");
    }
}

// Composite object (a folder, for example)
public class Folder : IComponent
{
    private string _name;
    private List<IComponent> _components = new List<IComponent>();

    public Folder(string name)
    {
        _name = name;
    }

    public void Add(IComponent component)
    {
        _components.Add(component);
    }

    public void Display()
    {
        Console.WriteLine($"Folder: {_name}");
        foreach (var component in _components)
        {
            component.Display();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create files and folders
        File file1 = new File("file1.txt");
        File file2 = new File("file2.txt");
        
        Folder folder1 = new Folder("Documents");
        folder1.Add(file1);
        folder1.Add(file2);

        // Display folder structure
        folder1.Display();
    }
}