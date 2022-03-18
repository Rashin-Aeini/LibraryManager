using LibraryManager.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(nameof(Category.CategoryName))
                .IsRequired()
                .HasMaxLength(250);

            builder.HasKey(nameof(Category.Id));

            builder.HasIndex(nameof(Category.CategoryName))
                .IsUnique();

            builder.HasData(
                new Category { Id = 1, CategoryName = "Book" },
                new Category { Id = 2, CategoryName = "Audio" },
                new Category { Id = 3, CategoryName = "Video" },
                new Category { Id = 4, CategoryName = "Refrence" },
                new Category { Id = 5, CategoryName = "Article" },
                new Category { Id = 6, CategoryName = "Newspaper" },
                new Category { Id = 7, CategoryName = "Magazine" },
                new Category { Id = 8, CategoryName = "EBook" }
                );
        }
    }
}
