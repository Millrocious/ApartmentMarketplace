using ApartmentMarketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentMarketplace.Data.Configuration;

public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasMaxLength(36)
            .IsFixedLength();
        
        builder.Property(a => a.Name)
            .HasMaxLength(99)
            .IsRequired();
        
        builder.Property(a => a.Rooms)
            .IsRequired();
        
        builder.Property(a => a.Price)
            .IsRequired();
        
        builder.Property(a => a.Description)
            .HasMaxLength(999)
            .IsRequired();
        
        builder.ToTable(tb => tb.HasCheckConstraint("CK_Apartment_Rooms", "\"Rooms\" > 0"));
        builder.ToTable(tb => tb.HasCheckConstraint("CK_Apartment_Price", "\"Price\" > 0"));
    }
}