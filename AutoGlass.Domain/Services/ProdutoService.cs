using AutoGlass.Domain.DTO;
using AutoGlass.Domain.Interfaces.Repository;
using AutoGlass.Domain.Interfaces.Services;
using AutoGlass.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGlass.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository,
            IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProdutoDTO> ObterTodosProdutos(string dataInicial = "", string dataFinal = "", string situacao = "", int page = 1)
        {
            var pageSize = 5;
            var erroData = string.Empty;
            DateTime? dtInicial = (DateTime?)null;
            DateTime? dtFinal = (DateTime?)null;

            page--;

            if (!string.IsNullOrWhiteSpace(dataInicial))
            {
                var dataInicialValida = Util.Util.DataValida(dataInicial);

                if (!dataInicialValida)
                    erroData += "A Data Inicial " + Util.Util.MensagemFormatoDataInvalida;
                else
                    dtInicial = Util.Util.FormatarData(dataInicial);
            }
            if (!string.IsNullOrWhiteSpace(dataFinal))
            {
                var dataFinalValida = Util.Util.DataValida(dataFinal);

                if (!dataFinalValida)
                    erroData += "A Data Final " + Util.Util.MensagemFormatoDataInvalida;
                else
                    dtFinal = Util.Util.FormatarData(dataFinal);
            }

            if (!string.IsNullOrWhiteSpace(erroData))
                throw new Exception(erroData);

            var produtos = _produtoRepository.GetAll().ToList();

            produtos = produtos.Where(x => (string.IsNullOrWhiteSpace(dataInicial) || x.DataFabricacao >= dtInicial)
                                        && (string.IsNullOrWhiteSpace(dataFinal) || x.DataFabricacao <= dtFinal)
                                        && (string.IsNullOrWhiteSpace(situacao) || x.Situacao.ToString().ToLower() == situacao.ToLower())).ToList();

            produtos = produtos.Skip(page-- * pageSize).Take(pageSize).ToList();

            return _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoDTO>>(produtos);
        }

        public ProdutoDTO ObterProduto(int codigo)
        {
            var produto = _produtoRepository.GetByCodigo(codigo);

            return _mapper.Map<Produto, ProdutoDTO>(produto);
        }

        public int InserirProduto(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);

            _produtoRepository.Create(produto);

            return produto.Codigo;
        }

        public void AtualizarProduto(int codigo, ProdutoDTO produtoDTO)
        {
            produtoDTO.Codigo = codigo;
            var produto = _produtoRepository.GetByCodigo(codigo);

            var produtoNew = _mapper.Map<Produto>(produtoDTO);

            produto.Descricao = produtoNew.Descricao;
            produto.DataFabricacao = produtoNew.DataFabricacao;
            produto.DataValidade = produtoNew.DataValidade;

            _produtoRepository.Update(produto);
        }

        public void DeletarProduto(int codigo)
        {
            var produto = _produtoRepository.GetByCodigo(codigo);

            produto.Situacao = false;

            _produtoRepository.Update(produto);
        }
    }
}
