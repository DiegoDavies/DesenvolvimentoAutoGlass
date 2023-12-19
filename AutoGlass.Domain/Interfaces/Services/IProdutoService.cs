using AutoGlass.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoGlass.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoDTO> ObterTodosProdutos(string dataInicial = "", string dataFinal = "", string situacao = "", int page = 1);
        ProdutoDTO ObterProduto(int codigo);
        int InserirProduto(ProdutoDTO produtoDTO);
        void AtualizarProduto(int codigo, ProdutoDTO produtoDTO);
        void DeletarProduto(int codigo);
    }
}
