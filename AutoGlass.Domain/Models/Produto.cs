using System;

namespace AutoGlass.Domain.Models
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        public bool Situacao { get; set; } = true;

        public int CodigoFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
