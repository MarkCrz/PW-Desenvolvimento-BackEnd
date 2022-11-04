using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebComerce.Models;
using WebComerce.Repositorios.Interfaces;

namespace WebComerce.Controllers
{
    [Route("api/private/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepositorio _produtoRepositorio;

        public ProdutosController(IProdutosRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorIdProdutos( int id)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorIdProdutos(id);
            return Ok(produto);
        }
        
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> CadastrarProdutos([FromBody] ProdutoModel produtos)
        {
            ProdutoModel user = await _produtoRepositorio.AdicionarProdutos(produtos);
            return Ok(user);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.id = id;
            ProdutoModel produto = await _produtoRepositorio.AtualizarProdutos(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Apagar(int id)
        {
            bool apagado = await _produtoRepositorio.ApagarProdutos(id);
            return Ok(apagado);
        }
    }
}
