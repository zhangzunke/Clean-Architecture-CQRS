using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Menu;
using Dinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Persistence.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dib => 
            {
                dib.ToTable("MenuDinnerIds");
                dib.WithOwner().HasForeignKey("MenuId");
                dib.HasKey("Id");

                dib.Property(d => d.Value)
                   .HasColumnName("DinnerId")
                   .ValueGeneratedNever();
                   
            });

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, dib =>
            {
                dib.ToTable("MenuReviewIds");
                dib.WithOwner().HasForeignKey("MenuId");
                dib.HasKey("Id");

                dib.Property(d => d.Value)
                   .HasColumnName("MenuReviewId")
                   .ValueGeneratedNever();

            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever()
                   .HasConversion(id => id.Value, value => MenuId.Create(value));

            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(128);

            builder.OwnsOne(m => m.AverageRating);

            builder.Property(x => x.HostId)
                   .ValueGeneratedNever()
                   .HasConversion(id => id.Value, value => HostId.Create(value));


        }

        private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.ToTable("MenuSections");

                sb.WithOwner().HasForeignKey("MenuId");

                sb.HasKey("Id", "MenuId");

                sb.Property(x => x.Id)
                  .HasColumnName("MenuSectionId")
                  .ValueGeneratedNever()
                  .HasConversion(id => id.Value, value => MenuSectionId.Create(value));

                sb.Property(x => x.Name).HasMaxLength(128);
                sb.Property(x => x.Description).HasMaxLength(128);

                sb.OwnsMany(s => s.Items, ib =>
                {
                    ib.ToTable("MenuItems");

                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    ib.HasKey("Id", "MenuSectionId", "MenuId");

                    ib.Property(i => i.Id)
                      .HasColumnName("MenuItemId")
                      .ValueGeneratedNever()
                      .HasConversion(id => id.Value, value => MenuItemId.Create(value));

                    ib.Property(x => x.Name).HasMaxLength(128);
                    ib.Property(x => x.Description).HasMaxLength(128);
                });

                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Navigation(s => s.Sections).Metadata.SetField("_setions");
            builder.Navigation(s => s.Sections).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
