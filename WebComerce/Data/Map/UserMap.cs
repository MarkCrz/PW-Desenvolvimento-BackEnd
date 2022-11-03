using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebComerce.Models;

namespace WebComerce.Data.Map;

public class UserMap : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(x => x.id);
        builder.Property(x => x.Username).IsRequired().HasMaxLength(60);
        builder.Property(x => x.password).IsRequired().HasMaxLength(60);
        builder.Property(x => x.admin).IsRequired();
    }
}