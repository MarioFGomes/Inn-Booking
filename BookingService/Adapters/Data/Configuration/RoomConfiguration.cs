using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration;
public class RoomConfiguration : IEntityTypeConfiguration<Room> {
    public void Configure(EntityTypeBuilder<Room> builder) 
    {
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.price)
            .Property(x => x.Currency);

        builder.OwnsOne(x => x.price)
            .Property(x => x.Value);
    }
}
