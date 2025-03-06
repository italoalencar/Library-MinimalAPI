using Library_MinimalAPI.Data;

namespace Library_MinimalAPI.DAL;

public class DAL<T> where T : class
{
    private readonly LibraryContext _context;

    public DAL(LibraryContext context)
    {
        _context = context;
    }

    public T Create(T obj)
    {
        _context.Set<T>().Add(obj);
        _context.SaveChanges();
        return obj;
    }

    public ICollection<T> Read()
    {
        return _context.Set<T>().ToList();
    }

    public T? ReadBy(Func<T, bool> condition)
    {
        return _context.Set<T>().FirstOrDefault(condition);
    }

    public bool Update(T updatedObject, Func<T, bool> condition)
    {
        var objectExists = _context.Set<T>().FirstOrDefault(condition);
        if (objectExists is null) return false;
        _context.Entry(objectExists).CurrentValues.SetValues(updatedObject);
        _context.SaveChanges();
        return true;    
    }

    public bool Delete(Func<T, bool> condition)
    {
        var toBeRemoved = _context.Set<T>().FirstOrDefault(condition);
        if (toBeRemoved is null) return false;
        _context.Set<T>().Remove(toBeRemoved);
        _context.SaveChanges();
        return true;
    }
}
