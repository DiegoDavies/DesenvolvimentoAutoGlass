using System;
using System.Collections.Generic;

namespace AutoGlass.Domain.Models
{
    public class Fornecedor
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        public bool Situacao { get; set; } = true;

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
