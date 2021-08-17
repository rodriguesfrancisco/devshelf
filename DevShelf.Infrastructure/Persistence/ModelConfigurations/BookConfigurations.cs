using DevShelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Infrastructure.Persistence.ModelConfigurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Notifications);

            builder.OwnsOne(x => x.Title)
                .Ignore(x => x.Notifications)
                .Property(x => x.Value)
                .HasColumnName("Title")
                .HasMaxLength(150);

            builder.OwnsOne(x => x.Author)
                .Ignore(x => x.Notifications)
                .Property(x => x.Name)
                .HasColumnName("Author")
                .HasMaxLength(120);

            builder.OwnsOne(x => x.Description)
                .Ignore(x => x.Notifications)
                .Property(x => x.Value)
                .HasColumnName("Description")
                .HasMaxLength(1000);

            builder.OwnsOne(x => x.Publisher)
                .Ignore(x => x.Notifications)
                .Property(x => x.Value)
                .HasColumnName("Publisher")
                .HasMaxLength(100);

            builder.HasOne(b => b.Category);
        }
    }
}
