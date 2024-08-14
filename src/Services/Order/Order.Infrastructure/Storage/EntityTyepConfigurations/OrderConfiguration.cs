using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Infrastructure.Storage.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Domain.Order>
{
    public void Configure(EntityTypeBuilder<Domain.Order> builder)
    {
        builder.ComplexProperty(o => o.ShippingAddress);

        builder.HasMany(o => o.OrderItems).WithOne().HasForeignKey(oi => oi.OrderId).IsRequired();
    }
}
