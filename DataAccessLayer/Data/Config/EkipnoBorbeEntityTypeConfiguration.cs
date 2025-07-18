using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Data.Config
{
    internal class EkipnoBorbeEntityTypeConfiguration : IEntityTypeConfiguration<EkipnoBorbe>
    {
       public void Configure(EntityTypeBuilder<EkipnoBorbe> builder)
        {
            builder.ToTable("ekipno_borbe");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdKLuba)
                .HasColumnName("id_kluba")
                .ValueGeneratedNever();

            builder.Property(x => x.ImeEkipe)
                .HasColumnName("ime_ekipe")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Uzrast)
                .HasColumnName("uzrast")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(x => x.Pol)
                .HasColumnName("pol")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
