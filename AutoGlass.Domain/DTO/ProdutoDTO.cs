using System;
using System.Collections.Generic;
using System.Text;

namespace AutoGlass.Domain.DTO
{
    public class ProdutoDTO
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string DataFabricacao { get; set; }
        public string DataValidade { get; set; }
        public string DataInclusao { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        public bool Situacao { get; set; } = true;

        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}
