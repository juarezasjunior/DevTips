// Produto base
public abstract class Documento
{
    public abstract void Imprimir();
}

// Produto concreto 1
public class PdfDocumento : Documento
{
    public override void Imprimir()
    {
        Console.WriteLine("Imprimindo documento PDF.");
    }
}

// Produto concreto 2
public class WordDocumento : Documento
{
    public override void Imprimir()
    {
        Console.WriteLine("Imprimindo documento Word.");
    }
}

// Classe criadora centralizada
public class DocumentoFactory
{
    public enum TipoDocumento
    {
        PDF,
        WORD
    }

    public Documento CriarDocumento(TipoDocumento tipo)
    {
        switch (tipo)
        {
            case TipoDocumento.PDF:
                return new PdfDocumento();
            case TipoDocumento.WORD:
                return new WordDocumento();
            default:
                throw new ArgumentException("Tipo de documento desconhecido.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DocumentoFactory factory = new DocumentoFactory();

        // Criar e imprimir um documento PDF
        Documento doc = factory.CriarDocumento(DocumentoFactory.TipoDocumento.PDF);
        doc.Imprimir();  // Saída: Imprimindo documento PDF.

        // Criar e imprimir um documento Word
        doc = factory.CriarDocumento(DocumentoFactory.TipoDocumento.WORD);
        doc.Imprimir();  // Saída: Imprimindo documento Word.
    }
}