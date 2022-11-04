namespace WebComerce.Models;

public class ProdutoEscolhidoModel
{
    public int id { get; set; }
    public int produtoId { get; set; }
    public virtual ProdutoModel? produto { get; set; }
    public int quantidade { get; set; }
}