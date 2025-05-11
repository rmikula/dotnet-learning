using ContainterTesting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddInMemoryCollection()
        .AddInMemoryCollection([
            new KeyValuePair<string, string?>("hello", "world"),
            new KeyValuePair<string, string?>("roman", "Mikula")
        ])
    ;

var configuration = builder.Build();


var services = new ServiceCollection();

services.AddScoped<IConfiguration>(_ => configuration);

services
    .AddLogging()
    .AddKeyedSingleton<IRepoService, RepoService>("RepoService")
    .AddKeyedSingleton<IRepoService, RepoService>("RepoService2")
    .AddSingleton<IRepoService, RepoService>()
    // .AddScoped<IRepoService, RepoService>()
    .AddSingleton<IPersonService, PersonService>()
    ;

var provider = services.BuildServiceProvider();


// Demo how to use ActivatorUtilities.

// var res = ActivatorUtilities.CreateInstance<PersonService>(provider, new Person("dkjfs", 3), "SomeService", myRepoService);
var res = ActivatorUtilities.CreateInstance<PersonService>(provider, new Person("RoMik", 3), "SomeService",
    "ServiceType");

res.StoreData(new Person("Roman", 55));

IServiceScopeFactory scopeFactory = provider.GetRequiredService<IServiceScopeFactory>();

// Create scope. Remember to dispose it.
using (var scope = scopeFactory.CreateScope())
{
    var repoService = scope.ServiceProvider.GetServices<IRepoService>();

    var p = new Person("Roman", 55);

    foreach (var repo in repoService)
    {
        repo.StoreData(p);
    }
}

// Create scope. Remember to dispose it.
using (var scope = scopeFactory.CreateScope())
{
    var repoService = scope.ServiceProvider.GetRequiredKeyedService<IRepoService>("RepoService");

    var p = new Person("Roman", 55);

    repoService.StoreData(p);
}


Console.WriteLine("Hello, World!");