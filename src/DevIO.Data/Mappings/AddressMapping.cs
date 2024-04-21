using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;
public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Street)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder.Property(x => x.Number)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder.Property(x => x.ZipCode)
            .IsRequired()
            .HasColumnType("VARCHAR(8)");

        builder.Property(x => x.Complement)
            .IsRequired()
            .HasColumnType("VARCHAR(250)");

        builder.Property(x => x.Neighborhood)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");

        builder.Property(x => x.City)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");

        builder.Property(x => x.State)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder.ToTable("Addresses");
    }
}
