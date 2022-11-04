using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebComerce.Models;
using WebComerce.Models.Enums;
using WebComerce.Repositorios.Interfaces;

namespace WebComerce.Controllers
{
    [Route("api/private/produto-escolhido")]
    [ApiController]
    public class ProdutoEscolhidoController : ControllerBase
    {
        private readonly IProdutoEscolhidoRepositorio _produtoEscolhidoRepositorio;
        private readonly IProdutosRepositorio _produtosRepositorio;

        public ProdutoEscolhidoController(IProdutoEscolhidoRepositorio produtoEscolhidoRepositorio, IProdutosRepositorio produtosRepositorio)
        {
            _produtoEscolhidoRepositorio = produtoEscolhidoRepositorio;
            _produtosRepositorio = produtosRepositorio;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ProdutoEscolhidoModel>>> BuscarTodosProdutosEscolhido()
        {
            List<ProdutoEscolhidoModel> produtosEscolhido = await _produtoEscolhidoRepositorio.BuscarTodosProdutosEscolhido();
            return Ok(produtosEscolhido);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoEscolhidoModel>> BuscarPorIdProdutoEscolhio( int id)
        {
            ProdutoEscolhidoModel produtoEscolhio = await _produtoEscolhidoRepositorio.BuscarPorIdProdutoEscolhio(id);
            return Ok(produtoEscolhio);
        }
        
        [HttpPost]
        public async Task<ActionResult<ProdutoEscolhidoModel>> CadastrarProdutoEscolhio([FromBody] ProdutoEscolhidoModel produtoEscolhido)
        {
            ProdutoModel produtoAtualizado = await _produtosRepositorio.BuscarPorIdProdutos(produtoEscolhido.produtoId);
            produtoAtualizado.quantidade = produtoAtualizado.quantidade - produtoEscolhido.quantidade;
            if (produtoAtualizado.quantidade == 0)
            {
                produtoAtualizado.possuiEstoque = Estoque.Vazio;
            }
            
            await _produtosRepositorio.AtualizarProdutos(produtoAtualizado, produtoAtualizado.id);
            ProdutoEscolhidoModel escolhidoModel = await _produtoEscolhidoRepositorio.AdicionarProdutoEscolhido(produtoEscolhido);
            return Ok(escolhidoModel);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoEscolhidoModel>> Atualizar([FromBody] ProdutoEscolhidoModel produtoEscolhidoModel, int id)
        {
            produtoEscolhidoModel.id = id;
            ProdutoModel produtoAtualizado = await _produtosRepositorio.BuscarPorIdProdutos(produtoEscolhidoModel.produtoId);
            produtoAtualizado.quantidade = produtoAtualizado.quantidade - produtoEscolhidoModel.quantidade;
            if (produtoAtualizado.quantidade == 0)
            {
                produtoAtualizado.possuiEstoque = Estoque.Vazio;
            }
            
            await _produtosRepositorio.AtualizarProdutos(produtoAtualizado, produtoAtualizado.id);
            ProdutoEscolhidoModel produtoEscolhido = await _produtoEscolhidoRepositorio.AtualizarProdutoEscolhido(produtoEscolhidoModel, id);
            return Ok(produtoEscolhido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoEscolhidoModel>> Apagar(int id)
        {
            bool apagado = await _produtoEscolhidoRepositorio.ApagarProdutoEscolhido(id);
            return Ok(apagado);
        }
    }
}
