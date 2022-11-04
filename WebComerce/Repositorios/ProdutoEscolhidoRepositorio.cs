using Microsoft.EntityFrameworkCore;
using WebComerce.Data;
using WebComerce.Models;
using WebComerce.Repositorios.Interfaces;

namespace WebComerce.Repositorios;

public class ProdutoEscolhidoRepositorio : IProdutoEscolhidoRepositorio
{
    private readonly UserDBContext _dbContext;
    
    public ProdutoEscolhidoRepositorio(UserDBContext userDbContext)
    {
        _dbContext = userDbContext;
    }
    
    public async Task<List<ProdutoEscolhidoModel>> BuscarTodosProdutosEscolhido()
    {
        return await _dbContext.ProdutoEscolhido.ToListAsync();
    }

    public async Task<ProdutoEscolhidoModel> BuscarPorIdProdutoEscolhio(int id)
    {
        return await _dbContext.ProdutoEscolhido.FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<ProdutoEscolhidoModel> AdicionarProdutoEscolhido(ProdutoEscolhidoModel produtoEscolhido)
    {
        await _dbContext.ProdutoEscolhido.AddAsync(produtoEscolhido);
        await _dbContext.SaveChangesAsync();

        return produtoEscolhido;
    }

    public async Task<ProdutoEscolhidoModel> AtualizarProdutoEscolhido(ProdutoEscolhidoModel produtoEscolhido, int id)
    {
        ProdutoEscolhidoModel produtoEscolhidoPorId = await BuscarPorIdProdutoEscolhio(id);
        if (produtoEscolhidoPorId == null)
        {
            throw new Exception($"Produto Escolhido para o ID: {id} não foi encontrado no banco de dados.");
        }

        produtoEscolhidoPorId.produto = produtoEscolhido.produto;
        produtoEscolhidoPorId.quantidade = produtoEscolhido.quantidade;

        _dbContext.ProdutoEscolhido.Update(produtoEscolhidoPorId);
        await _dbContext.SaveChangesAsync();

        return produtoEscolhidoPorId;
    }

    public async Task<bool> ApagarProdutoEscolhido(int id)
    {
        ProdutoEscolhidoModel produtoEscolhidoPorId = await BuscarPorIdProdutoEscolhio(id);
        if (produtoEscolhidoPorId == null)
        {
            throw new Exception($"Produto Escolhido para o ID: {id} não foi encontrado no banco de dados.");
        }

        _dbContext.ProdutoEscolhido.Remove(produtoEscolhidoPorId);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}