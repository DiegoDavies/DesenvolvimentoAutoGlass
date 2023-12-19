using AutoGlass.Domain.DTO;
using AutoGlass.Domain.Util;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoGlass.Domain.Validations
{
    public class ProdutoValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.DataFabricacao).Must(p => Util.Util.DataValida(p)).WithMessage("A Data de Fabricação " + Util.Util.MensagemFormatoDataInvalida);
            RuleFor(p => p.DataValidade).Must(p => Util.Util.DataValida(p)).WithMessage("A Data de Validade " + Util.Util.MensagemFormatoDataInvalida);
            RuleFor(p => p).Custom((p, context) =>
            {
                var dataFabricacaoValida = Util.Util.DataValida(p.DataFabricacao);
                var dataValidadeValida = Util.Util.DataValida(p.DataValidade);
                if (dataFabricacaoValida && dataValidadeValida)
                {
                    var dataFabricacao = Util.Util.FormatarData(p.DataFabricacao);
                    var dataValidade = Util.Util.FormatarData(p.DataValidade);
                    if (dataFabricacao >= dataValidade)
                        context.AddFailure("A Data de Fabricação precisa ser menor que a Data de Validade");
                }
            });
        }
    }
}
