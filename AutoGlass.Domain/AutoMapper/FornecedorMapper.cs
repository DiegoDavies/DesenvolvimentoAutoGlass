using AutoGlass.Domain.DTO;
using AutoGlass.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoGlass.Domain.AutoMapper
{
    public static class FornecedorMapper
    {
        public static void MapearFornecedor(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMap<Fornecedor, FornecedorDTO>()
                    .ForMember(f => f.DataInclusao, m => m.MapFrom(ft => ft.DataInclusao.ToString("dd/MM/yyyy HH:mm:ss")));
        }
    }
}
