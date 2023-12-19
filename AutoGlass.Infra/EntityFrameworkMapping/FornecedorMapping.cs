using System;
using AutoGlass.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoGlass.Infra.EntityFrameworkMapping
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Codigo);
            builder.Property(f => f.Codigo).ValueGeneratedOnAdd();

            builder.Property(f => f.Descricao).IsRequired(true);

            #region Dados Ficticios
            builder.HasData(new Fornecedor() { Codigo = 1, CNPJ = "12775524000133", Descricao = "Fornecedor 1", DataInclusao = DateTime.Now, Situacao = true });
            builder.HasData(new Fornecedor() { Codigo = 2, CNPJ = "09809005000134", Descricao = "Fornecedor 2", DataInclusao = DateTime.Now.AddHours(-5), Situacao = true });
            builder.HasData(new Fornecedor() { Codigo = 3, CNPJ = "40575582000159", Descricao = "Fornecedor 3", DataInclusao = DateTime.Now.AddDays(-1), Situacao = true });
            builder.HasData(new Fornecedor() { Codigo = 4, CNPJ = "27283103000162", Descricao = "Fornecedor 4", DataInclusao = DateTime.Now.AddDays(-7), Situacao = true });
            #endregion
        }
    }
}
