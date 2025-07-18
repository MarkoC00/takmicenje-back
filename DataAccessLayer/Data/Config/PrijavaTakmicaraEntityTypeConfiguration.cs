using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Data.Config
{
    internal class PrijavaTakmicaraEntityTypeConfiguration : IEntityTypeConfiguration<PrijavaTakmicara>
    {
        public void Configure (EntityTypeBuilder<PrijavaTakmicara> builder)
        {
            builder.ToTable("prijava_takmicara");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdTakmicara)
                          .HasColumnName("id_takmicara")
                          .ValueGeneratedNever();

            builder.Property(x => x.IdEkipe)
                          .HasColumnName("ekipno_kate_id")
                          .ValueGeneratedNever();

            builder.Property(x => x.GodisteTakmicara)
                .HasColumnName("godiste_takmicara")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(x => x.KlasaTakmicara)
                .HasColumnName("klasa_takmicara")
                .HasMaxLength(3)
                .IsRequired();
            

            builder.Property(x => x.Klasa)
                .HasColumnName("klasa")
                .IsRequired();

            builder.Property(x => x.Apsolutni)
                .HasColumnName("absolutno")
                .IsRequired();

            builder.Property(x => x.PolTakmicara)
                .HasColumnName("pol_takmicara")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(x => x.Ekipno)
                .HasColumnName("ekipno")
                .IsRequired();
        }
    }
}
