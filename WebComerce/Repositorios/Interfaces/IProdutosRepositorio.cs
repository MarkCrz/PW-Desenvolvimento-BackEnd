using WebComerce.Models;

namespace WebComerce.Repositorios.Interfaces;

public interface IProdutosRepositorio
{
    Task<List<ProdutoModel>> BuscarTodosProdutos();
    Task<ProdutoModel> BuscarPorIdProdutos(int id);
    Task<ProdutoModel> AdicionarProdutos(ProdutoModel produtoModel);
    Task<ProdutoModel> AtualizarProdutos(ProdutoModel produto, int id);
    Task<bool> ApagarProdutos(int id);
}