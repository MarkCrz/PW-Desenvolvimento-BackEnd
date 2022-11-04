using WebComerce.Models;

namespace WebComerce.Repositorios.Interfaces;

public interface IProdutoEscolhidoRepositorio
{
    Task<List<ProdutoEscolhidoModel>> BuscarTodosProdutosEscolhido();
    Task<ProdutoEscolhidoModel> BuscarPorIdProdutoEscolhio(int id);
    Task<ProdutoEscolhidoModel> AdicionarProdutoEscolhido(ProdutoEscolhidoModel produtoEscolhido);
    Task<ProdutoEscolhidoModel> AtualizarProdutoEscolhido(ProdutoEscolhidoModel produtoEscolhido, int id);
    Task<bool> ApagarProdutoEscolhido(int id);
}