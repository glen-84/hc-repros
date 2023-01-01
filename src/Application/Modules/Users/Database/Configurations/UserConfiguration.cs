using Application.Modules.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Modules.Users.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table.

        builder.ToTable("users");

        // Properties.

        builder.Property(u => u.Id)
            .HasColumnType("int(11)");

        builder.Property(u => u.EmailAddress)
            .HasColumnName("email")
            .HasMaxLength(60);

        builder.Property(u => u.Username)
            .HasMaxLength(20);

        // Indexes.

        builder.HasIndex(u => u.EmailAddress)
            .IsUnique();

        builder.HasIndex(u => u.Username)
            .IsUnique();
    }
}
