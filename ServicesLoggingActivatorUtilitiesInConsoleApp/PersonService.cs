namespace ContainterTesting;

public class PersonService : IPersonService
{
    private readonly IRepoService _repoService;
    private readonly string _serviceName;
    private readonly string _serviceType;
    private readonly Person _init;

    public PersonService(IRepoService repoService, string serviceName, string serviceType, Person init)
    {
        _repoService = repoService;
        _serviceName = serviceName;
        _serviceType = serviceType;
        _init = init;
    }

    public string Name { get; init; } = "Ubuntu";
    public void StoreData(Person person)
    {
        _repoService.StoreData(person);
    }
}