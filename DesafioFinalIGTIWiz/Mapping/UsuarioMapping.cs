using DesafioFinalIGTIWiz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);                          // Definindo a chave primária
            builder.HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId);                  // Definindo chave primária
            builder.Property(x => x.Nome).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.CriadoEm).HasColumnType("Datetime").IsRequired();
            builder.ToTable("usuarios");                        // Definindo o nome da tabela
        }
    }
}
