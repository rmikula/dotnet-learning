namespace ContainterTesting;

public interface IRepoService
{
    void StoreData(Person person);
}

public class RepoService : IRepoService
{
    private readonly string _name;

    public RepoService(string name)
    {
        _name = name;
    }

    public RepoService()
    {
        _name = "Default";
    }

    public void StoreData(Person person)
    {
        Console.WriteLine($"Storing data {person} {person.GetHashCode()}");
    }
}