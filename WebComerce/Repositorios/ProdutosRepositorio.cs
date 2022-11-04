using Microsoft.EntityFrameworkCore;
using WebComerce.Data;
using WebComerce.Models;
using WebComerce.Repositorios.Interfaces;

namespace WebComerce.Repositorios;

public class ProdutosRepositorio : IProdutosRepositorio
{
    private readonly UserDBContext _dbContext;
    
    public ProdutosRepositorio(UserDBContext userDbContext)
    {
        _dbContext = userDbContext;
    }

    public async Task<List<ProdutoModel>> BuscarTodosProdutos()
    {
        return await _dbContext.Produtos.ToListAsync();
    }

    public async Task<ProdutoModel> BuscarPorIdProdutos(int id)
    {
        return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.id == id);
    }
    
    public async Task<ProdutoModel> AdicionarProdutos(ProdutoModel produtoModel)
    {
        await _dbContext.Produtos.AddAsync(produtoModel);
        await _dbContext.SaveChangesAsync();

        return produtoModel;
    }

    public async Task<ProdutoModel> AtualizarProdutos(ProdutoModel produto, int id)
    {
        ProdutoModel produtoPorId = await BuscarPorIdProdutos(id);
        if (produtoPorId == null)
        {
            throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
        }

        produtoPorId.nome = produto.nome;
        produtoPorId.quantidade = produto.quantidade;
        produtoPorId.valor = produto.valor;
        produtoPorId.possuiEstoque = produto.possuiEstoque;

        _dbContext.Produtos.Update(produtoPorId);
        await _dbContext.SaveChangesAsync();

        return produtoPorId;
    }

    public async Task<bool> ApagarProdutos(int id)
    {
        ProdutoModel produtoPorId = await BuscarPorIdProdutos(id);
        if (produtoPorId == null)
        {
            throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
        }

        _dbContext.Produtos.Remove(produtoPorId);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}