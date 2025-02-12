// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using RolesAndEntityFramework.Database;

namespace RolesAndEntityFramework;

internal class Program
{
    public static void Main(string[] args)
    {
        var str = "Hello, World!";
        Console.WriteLine(str);


        using var ctx = new AppDbContext(new DbContextOptions<AppDbContext>());

        // ctx.Database.EnsureCreated();

        using var conn = ctx.Database.GetDbConnection();

        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "select sysdate from dual";

        var datetime = cmd.ExecuteScalar() as DateTime?;

        Console.WriteLine(datetime);

        // var res = ctx.Database.SqlQuery<DateTime>(FormattableStringFactory.Create("select sysdate from dual"));

        var id = 1;

        var xx = ctx.Roles.Where(c => c.Id == id);

        foreach (var role in xx)
        {
            Console.WriteLine(role);
        }
        
        var max = ctx.Roles.Max(f => f.Id);
        Console.WriteLine(max);
        
        
        
    }
}