using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;
public class SupplierMapping : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder.Property(x => x.Document)
            .IsRequired()
            .HasColumnType("VARCHAR(14)");

        builder.HasOne(x => x.Address)
            .WithOne(x => x.Supplier);

        builder.HasMany(x => x.Products)
            .WithOne(x => x.Supplier)
            .HasForeignKey(p => p.SupplierId);

        builder.ToTable("Suppliers");
    }
}
