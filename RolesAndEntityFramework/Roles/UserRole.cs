namespace RolesAndEntityFramework.Roles;

internal sealed class UserRole
{
    public Guid UserId { get; init; }
    public int RoleId { get; init; }
    
    public User User { get; init; }
    public Role Role { get; init; }
}