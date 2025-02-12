# Instalace dotnet-ef

```
dotnet tool install --global dotnet-ef
```
or update
```
dotnet tool update --global dotnet-ef
```

Before you can use the tools on a specific project, you'll need to add the Microsoft.EntityFrameworkCore.Design package to it.

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

# Verify installation
```
dotnet ef
```

## Documentation
https://learn.microsoft.com/en-us/ef/core/cli/dotnet


# Init database

## Problems with oracle
In the oracle we cannot create schema with EF (as I know) 

create user INTERFACE identified by atlantis default tablespace USERS temporary tablespace TEMP
/

alter user INTERFACE  quota  unlimited on users
/