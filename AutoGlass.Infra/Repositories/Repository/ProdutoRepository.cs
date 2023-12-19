using AutoGlass.Domain.Interfaces.Repository;
using AutoGlass.Domain.Models;
using AutoGlass.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoGlass.Infra.Repositories.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(SqlContext context) : base(context)
        {

        }
    }
}
