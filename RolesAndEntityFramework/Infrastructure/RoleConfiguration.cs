using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolesAndEntityFramework.Roles;
    
namespace RolesAndEntityFramework.Infrastructure;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(role => role.Id);
        builder.Property(role => role.Name).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Role()
            {
                Id = Role.AdminId,
                Name = Role.Admin
            },
            new Role()
            {
                Id = Role.MemberId,
                Name = Role.Member
            }
        );
    }
}