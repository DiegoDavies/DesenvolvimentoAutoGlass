using System;
using System.Collections.Generic;
using System.Text;

namespace AutoGlass.Domain.DTO
{
    public class FornecedorDTO
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }
        public string DataInclusao { get; set; }
        public bool Situacao { get; set; }
    }
}
