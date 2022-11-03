using Microsoft.EntityFrameworkCore;
using WebComerce.Data;
using WebComerce.Models;
using WebComerce.Repositorios.Interfaces;

namespace WebComerce.Repositorios;

public class UserRepositorio :IUserRepositorio
{
    private readonly UserDBContext _dbContext;
    public UserRepositorio(UserDBContext userDbContext)
    {
        _dbContext = userDbContext;
    }
    
    public async Task<List<UserModel>> BuscarTodosUsuarios()
    {
        return await _dbContext.Usuarios.ToListAsync();
    }

    public async Task<UserModel> BuscarPorId(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<UserModel> Adicionar(UserModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();

        return usuario;
    }

    public async Task<UserModel> Atualizar(UserModel usuario, int id)
    {
        UserModel usuarioPorId = await BuscarPorId(id);
        if (usuarioPorId == null)
        {
            throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
        }

        usuarioPorId.Username = usuario.Username;
        usuarioPorId.password = usuario.password;
        usuarioPorId.admin = usuario.admin;

        _dbContext.Usuarios.Update(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return usuarioPorId;
    }

    public async Task<bool> Apagar(int id)
    {
        UserModel usuarioPorId = await BuscarPorId(id);
        if (usuarioPorId == null)
        {
            throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
        }

        _dbContext.Usuarios.Remove(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}