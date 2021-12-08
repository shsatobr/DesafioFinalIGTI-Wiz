using DesafioFinalIGTIWiz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Mapping
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Id);                                          // Definindo a chave
            builder.Property(x => x.Descricao).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.ISBN).IsRequired();
            builder.Property(x => x.AnoLancamento).IsRequired();
            builder.Property(x => x.CriadoEm).HasColumnType("Datetime").IsRequired();
            builder.HasOne(x => x.Autor)
                .WithMany()                                                     
                .HasForeignKey(x => x.AutorId);                                 // Definindo o campo de chave estrangeira
            builder.ToTable("livros");                                          // Definindo o nome da tabela
        }
    }
}
