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
    [Route("api/usuarios")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;

        public UserController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsuarios()
        {
            List<UserModel> users = await _userRepositorio.BuscarTodosUsuarios();
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> BuscarPorId( int id)
        {
            UserModel user = await _userRepositorio.BuscarPorId(id);
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel usuario)
        {
            UserModel user = await _userRepositorio.Adicionar(usuario);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Atualizar([FromBody] UserModel userModel, int id)
        {
            userModel.id = id;
            UserModel usuario = await _userRepositorio.Atualizar(userModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Apagar(int id)
        {
            bool apagado = await _userRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
