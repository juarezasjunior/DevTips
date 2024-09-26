// Iterator Interface
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Collection Interface
public interface ICollection<T>
{
    IIterator<T> CreateIterator();
}

// Implementation of Item Collection
public class ItemCollection : ICollection<string>
{
    private List<string> _items = new List<string>();

    public void AddItem(string item)
    {
        _items.Add(item);
    }

    public IIterator<string> CreateIterator()
    {
        return new ItemIterator(this);
    }

    public List<string> GetItems()
    {
        return _items;
    }
}

// Implementation of Iterator for the Item Collection
public class ItemIterator : IIterator<string>
{
    private ItemCollection _collection;
    private int _position = 0;

    public ItemIterator(ItemCollection collection)
    {
        _collection = collection;
    }

    public bool HasNext()
    {
        return _position < _collection.GetItems().Count;
    }

    public string Next()
    {
        if (HasNext())
        {
            return _collection.GetItems()[_position++];
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an item collection
        ItemCollection collection = new ItemCollection();
        collection.AddItem("Item 1");
        collection.AddItem("Item 2");
        collection.AddItem("Item 3");

        // Create the iterator
        IIterator<string> iterator = collection.CreateIterator();

        // Traverse the collection using the iterator
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}