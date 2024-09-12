// Base product
public abstract class Document
{
    public abstract void Print();
}

// Concrete product 1
public class PdfDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing PDF document.");
    }
}

// Concrete product 2
public class WordDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing Word document.");
    }
}

// Centralized creator class
public class DocumentFactory
{
    public enum DocumentType
    {
        PDF,
        WORD
    }

    public Document CreateDocument(DocumentType type)
    {
        switch (type)
        {
            case DocumentType.PDF:
                return new PdfDocument();
            case DocumentType.WORD:
                return new WordDocument();
            default:
                throw new ArgumentException("Unknown document type.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DocumentFactory factory = new DocumentFactory();

        // Create and print a PDF document
        Document doc = factory.CreateDocument(DocumentFactory.DocumentType.PDF);
        doc.Print();  // Output: Printing PDF document.

        // Create and print a Word document
        doc = factory.CreateDocument(DocumentFactory.DocumentType.WORD);
        doc.Print();  // Output: Printing Word document.
    }
}