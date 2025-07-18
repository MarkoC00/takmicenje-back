using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Data.Config 

{
    internal class TakmicarEntityTypeConfiguration : IEntityTypeConfiguration<Takmicar>
    {
        public void Configure(EntityTypeBuilder<Takmicar> builder)
        {
            builder.ToTable("takmicar");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.IdKluba)
               .HasColumnName("id_klub")
               .ValueGeneratedNever();

            builder.Property(t => t.Ime)
                .HasColumnName("ime")
                .HasMaxLength(20)
                .IsRequired();
             
            builder.Property(t => t.Prezime)
                .HasColumnName("prezime")
                .HasMaxLength(30)
                .IsRequired();
           
            builder.Property(t => t.Pol)
                .HasColumnName("pol")
                .HasConversion(
            v => v.ToString(),
            v => (Pol)Enum.Parse(typeof(Pol), v))
                .IsRequired();


            builder.Property(t => t.Godiste)
                .HasColumnName("godiste")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(t => t.Pojas)
                .HasColumnName("pojas")
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
