using DesafioFinalIGTIWiz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);                      // Definindo a chave
            builder.Property(x => x.Nome).HasColumnType("varchar(30)").IsRequired();
            builder.ToTable("roles");                       // Definindo o nome da tabela
        }
    }
}
