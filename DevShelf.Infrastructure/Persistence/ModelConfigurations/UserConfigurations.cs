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
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Notifications);

            builder.OwnsOne(x => x.Email)
               .Ignore(x => x.Notifications)
               .Property(x => x.Value)
               .HasColumnName("Email")
               .HasMaxLength(150);

            builder.OwnsOne(x => x.Name)
               .Ignore(x => x.Notifications)
               .Property(x => x.Value)
               .HasColumnName("Name")
               .HasMaxLength(240);
        }
    }
}
