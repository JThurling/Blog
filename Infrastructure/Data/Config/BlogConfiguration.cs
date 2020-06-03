using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BlogConfiguration : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.HasOne(b => b.BlogAuthor).WithMany()
                .HasForeignKey(k => k.BlogAuthorId);
            builder.HasOne(f => f.BlogCategories).WithMany()
                .HasForeignKey(f => f.BlogCategoryId);
            builder.HasOne(k => k.Tags).WithMany()
                .HasForeignKey(f => f.TagId);
        }
    }
}