using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;

namespace DDDCQRS.Microservice.Infrastructure.EntityConfigurations 
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure (EntityTypeBuilder<Product> builder) 
        {

            builder.ToTable ("Product");

            builder.HasKey (o => o.Id);

            builder.Ignore (o => o.DomainEvents);

            builder.Property (o => o.Id).ValueGeneratedOnAdd ();

            builder.Property<int?> ("_categoryId")
                .HasColumnName ("ProductCategoryId")
                .IsRequired (false);

            builder.Property<string> ("_name")
                .HasColumnName ("Name")
                .IsRequired (true);

            builder.Property<string> ("_description")
                .HasColumnName ("Description")
                .IsRequired (true);

            builder.Property<int> ("_price")
                .HasColumnName ("Price")
                .IsRequired (true);

            builder.HasOne<Category> ()
                .WithMany ()
                .IsRequired (false).HasForeignKey ("_categoryId");
        }
    }
}