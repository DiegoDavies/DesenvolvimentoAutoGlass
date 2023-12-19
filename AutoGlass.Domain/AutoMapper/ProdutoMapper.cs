using AutoGlass.Domain.DTO;
using AutoGlass.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AutoGlass.Domain.AutoMapper
{
    public static class ProdutoMapper
    {
        public static void MapearProduto(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMap<Produto, ProdutoDTO>()
                .ForMember(p => p.CodigoFornecedor, m => m.MapFrom(pt => pt.Fornecedor.Codigo))
                .ForMember(p => p.DescricaoFornecedor, m => m.MapFrom(pt => pt.Fornecedor.Descricao))
                .ForMember(p => p.CNPJFornecedor, m => m.MapFrom(pt => pt.Fornecedor.CNPJ))
                .ForMember(f => f.DataFabricacao, m => m.MapFrom(ft => ft.DataFabricacao.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(f => f.DataValidade, m => m.MapFrom(ft => ft.DataValidade.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(f => f.DataInclusao, m => m.MapFrom(ft => ft.DataInclusao.ToString("dd/MM/yyyy HH:mm:ss")));

            mapperConfiguration.CreateMap<ProdutoDTO, Produto>()
                .ForMember(p => p.DataValidade, m => m.MapFrom(pt => Util.Util.FormatarData(pt.DataValidade)))
                .ForMember(p => p.DataFabricacao, m => m.MapFrom(pt => Util.Util.FormatarData(pt.DataFabricacao)));
        }
    }
}
