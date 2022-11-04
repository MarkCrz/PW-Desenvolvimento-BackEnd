using WebComerce.Models.Enums;

namespace WebComerce.Models;

public class ProdutoModel
{
    public  int id { get; set; }
    
    public string nome { get; set; }
    
    public int quantidade { get; set; }
    
    public double valor { get; set; }
    
    public Estoque possuiEstoque { get; set; }
}