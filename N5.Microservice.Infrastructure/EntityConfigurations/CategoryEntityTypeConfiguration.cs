using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate;

namespace DDDCQRS.Microservice.Infrastructure.EntityConfigurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("ProductCategory");

            builder.HasKey(o => o.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder.Property<string>("_name").HasColumnName("Name").IsRequired(true);
            builder.Property<string>("_description").HasColumnName("Description").IsRequired(true);
        }
    }
}