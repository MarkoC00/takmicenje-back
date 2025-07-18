using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataAccessLayer.Data.Config
{
    internal class PrijavaTakmicaraBorbeEntityTypeConfiguration : IEntityTypeConfiguration<PrijavaTakmicaraBorbe>
    {
        public void Configure(EntityTypeBuilder<PrijavaTakmicaraBorbe> builder)
        {
            builder.ToTable("prijava_takmicara_borbe");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdTakmicara)
                .HasColumnName("id_takmicara")
                .ValueGeneratedNever();

            builder.Property(x => x.IdEkipe)
                .HasColumnName("id_ekipe")
                .ValueGeneratedNever();

            builder.Property(x => x.Kilaza)
                .HasColumnName("kilaza")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(x => x.Pol)
                .HasColumnName("pol")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Godiste)
                .HasColumnName("godiste")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Individualno)
                .HasColumnName("individualno")
                .IsRequired();

            builder.Property(x => x.Ekipno)
                .HasColumnName("ekipno")
                .IsRequired();

        }
    }

    
}
