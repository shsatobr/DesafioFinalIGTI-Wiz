using DesafioFinalIGTIWiz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Mapping
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(x => x.Id);                  // Definindo a chave primária
            builder.Property(x => x.Nome).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.Sobrenome).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.CriadoEm).HasColumnType("Datetime").IsRequired();
            builder.ToTable("autores");                 // Definindo nome da tabela
        }
    }
}
