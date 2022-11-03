using WebComerce.Models;

namespace WebComerce.Repositorios.Interfaces;

public interface IUserRepositorio
{
    Task<List<UserModel>> BuscarTodosUsuarios();
    Task<UserModel> BuscarPorId(int id);
    Task<UserModel> Adicionar(UserModel usuario);
    Task<UserModel> Atualizar(UserModel usuario, int id);
    Task<bool> Apagar(int id);
}