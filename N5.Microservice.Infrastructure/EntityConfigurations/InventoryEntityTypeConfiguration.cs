using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;

namespace DDDCQRS.Microservice.Infrastructure.EntityConfigurations
{
    public class InventoryEntityTypeConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable ("Inventory");

            builder.HasKey (o => o.Id);

            builder.Ignore (o => o.DomainEvents);

            builder.Property (o => o.Id).ValueGeneratedOnAdd ();

            builder.Property<int> ("_categoryId")
                .HasColumnName ("ProductCategoryId")
                .IsRequired ();

            builder.Property<int> ("_stock")
                .HasColumnName ("Stock")
                .IsRequired (true);

            builder.Property<DateTime> ("_date")
                .HasColumnName ("Date")
                .IsRequired (true); 
                
            builder.HasOne<Category>()
                .WithMany()
                .IsRequired(false)
                .HasForeignKey("_categoryId");  
        }
    }
}