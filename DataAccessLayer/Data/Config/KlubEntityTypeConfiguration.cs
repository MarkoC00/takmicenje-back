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
    internal class KlubEntityTypeConfiguration : IEntityTypeConfiguration<Klub>
    {
        public void Configure (EntityTypeBuilder<Klub> builder)
        {
            builder.ToTable("klub");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(260)
                .IsRequired();

            builder.Property(x => x.HashSifra)
                .HasColumnName("hash_sifra")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.ImeKluba)
                .HasColumnName("ime_kluba")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Grad)
                .HasColumnName("grad")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Zip)
                .HasColumnName("zip")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Drzava)
                .HasColumnName("drzava")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Adresa)
                .HasColumnName("adresa")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.BrojTelefona)
                .HasColumnName("broj_telefona")
                .HasMaxLength(15)
                .IsRequired();

        }
    }
}
