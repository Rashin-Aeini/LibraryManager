using LibraryManager.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LibraryManager.Models.Configurations
{
    public class LibraryItemConfiguration : IEntityTypeConfiguration<LibraryItem>
    {
        public void Configure(EntityTypeBuilder<LibraryItem> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.Title)
                .IsRequired();

            builder.Property(item => item.Type)
                .IsRequired();

            builder.Property(item => item.Author)
                .IsRequired(false);

            builder.Property(item => item.Pages)
                .IsRequired(false);

            builder.Property(item => item.RunTimeMinutes)
                .IsRequired(false);

            builder.Property(item => item.IsBorrowable)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(item => item.Category)
                .WithMany(category => category.LibraryItems)
                .HasForeignKey(item => item.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
