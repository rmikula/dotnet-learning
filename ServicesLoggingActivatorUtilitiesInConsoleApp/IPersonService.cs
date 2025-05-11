namespace ContainterTesting;

public interface IPersonService
{
    string Name { get; }
    
    void StoreData(Person person);
}