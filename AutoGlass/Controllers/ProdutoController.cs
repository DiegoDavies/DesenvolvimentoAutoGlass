using AutoGlass.Domain.Interfaces.Services;
using AutoGlass.Domain.Services;
using AutoGlass.Domain.DTO;
using AutoGlass.Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGlass.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            return Ok(_produtoService.ObterTodosProdutos());
        }

        [HttpGet("ObterProdutos")]
        public IActionResult ObterProdutos(string dataInicial = "", string dataFinal = "", string situacao = "", int page = 1)
        {
            try
            {
                return Ok(_produtoService.ObterTodosProdutos(dataInicial, dataFinal, situacao, page));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ObterProduto/{codigo}")]
        public IActionResult ObterProduto(int codigo)
        {
            return Ok(_produtoService.ObterProduto(codigo));
        }

        [HttpPost("InserirProduto")]
        public IActionResult InserirProduto(ProdutoDTO produtoDTO)
        {
            try
            {
                var codigo = _produtoService.InserirProduto(produtoDTO);

                return Ok(_produtoService.ObterProduto(codigo));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("AtualizarProduto/{codigo}")]
        public IActionResult AtualizarProduto(int codigo, ProdutoDTO produtoDTO)
        {
            try
            {
                _produtoService.AtualizarProduto(codigo, produtoDTO);

                return Ok(_produtoService.ObterProduto(codigo));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("DeletarProduto/{codigo}")]
        public IActionResult DeletarProduto(int codigo)
        {
            try
            {
                _produtoService.DeletarProduto(codigo);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
