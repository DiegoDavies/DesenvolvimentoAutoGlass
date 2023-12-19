using System;
using AutoGlass.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoGlass.Infra.EntityFrameworkMapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao).IsRequired(true);

            builder.HasOne(p => p.Fornecedor).WithMany(f => f.Produtos).HasForeignKey(p => p.CodigoFornecedor).OnDelete(DeleteBehavior.Restrict);

            #region Dados Ficticios
            builder.HasData(new Produto() { Codigo = 1, Descricao = "Arroz", DataFabricacao = new DateTime(2023, 10, 20, 20, 40, 10), DataValidade = new DateTime(2024, 10, 20), CodigoFornecedor = 1, DataInclusao = DateTime.Now, Situacao = true });
            builder.HasData(new Produto() { Codigo = 2, Descricao = "Coca Cola", DataFabricacao = new DateTime(2023, 11, 15, 07, 40, 10), DataValidade = new DateTime(2024, 01, 20), CodigoFornecedor = 2, DataInclusao = DateTime.Now, Situacao = true });
            #endregion
        }
    }
}
