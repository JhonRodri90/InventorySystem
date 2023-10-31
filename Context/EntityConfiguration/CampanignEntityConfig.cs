using Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfiguration
{
    internal class CampanignEntityConfig : IEntityTypeConfiguration<Campanign>
    {
        public void Configure(EntityTypeBuilder<Campanign> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Country).HasMaxLength(60);
            builder.Property(x => x.City).HasMaxLength(60);
            builder.Property(x => x.Address).HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(40);
            builder.Property(x => x.CreatedById).IsRequired();
            builder.Property(x => x.UpdatedById).IsRequired();
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.DateUpdate);

            //Relations
            builder.HasOne(x => x.CreatedBy).WithMany()
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.UpdatedBy).WithMany()
                .HasForeignKey(x => x.UpdatedById)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
