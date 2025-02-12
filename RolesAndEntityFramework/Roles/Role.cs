using System.ComponentModel.DataAnnotations.Schema;

namespace RolesAndEntityFramework.Roles;

// Table("Role", Schema = "interface")
internal sealed class Role
{
    internal const string Admin = "Admin";
    internal const string Member = "Member";
    
    internal const int AdminId = 1;
    internal const int MemberId = 2;
    
    
    
    public int Id { get; init; }
    public string Name { get; init; }
}