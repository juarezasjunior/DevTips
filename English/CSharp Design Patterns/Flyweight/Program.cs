// Flyweight: File Icon
public class FileIcon
{
    private string _iconName;

    public FileIcon(string iconName)
    {
        _iconName = iconName;
        Console.WriteLine($"Loading icon {_iconName} from memory...");
    }

    public void Display(int size)
    {
        Console.WriteLine($"Displaying icon {_iconName} with size {size}.");
    }
}

// Flyweight Factory: File icon manager
public class IconFactory
{
    private Dictionary<string, FileIcon> _icons = new Dictionary<string, FileIcon>();

    public FileIcon GetIcon(string fileType)
    {
        if (!_icons.ContainsKey(fileType))
        {
            _icons[fileType] = new FileIcon(fileType);
        }
        return _icons[fileType];
    }
}

// Class representing an individual file
public class File
{
    private string _name;
    private FileIcon _icon;

    public File(string name, FileIcon icon)
    {
        _name = name;
        _icon = icon;
    }

    public void Display()
    {
        Console.WriteLine($"Displaying file: {_name}");
        _icon.Display(32);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IconFactory factory = new IconFactory();

        // Load and share icons for different file types
        FileIcon pdfIcon = factory.GetIcon("PDF");
        FileIcon wordIcon = factory.GetIcon("Word");
        FileIcon imageIcon = factory.GetIcon("Image");

        // Create files with shared icons
        File file1 = new File("Document1.pdf", pdfIcon);
        File file2 = new File("Document2.pdf", pdfIcon);
        File file3 = new File("Report.docx", wordIcon);
        File file4 = new File("Photo.jpg", imageIcon);

        // Display files with their icons
        file1.Display();  // Output: Displaying file: Document1.pdf. Displaying icon PDF with size 32.
        file2.Display();  // Output: Displaying file: Document2.pdf. Displaying icon PDF with size 32.
        file3.Display();  // Output: Displaying file: Report.docx. Displaying icon Word with size 32.
        file4.Display();  // Output: Displaying file: Photo.jpg. Displaying icon Image with size 32.
    }
}