using Domain.Data.ViewModels;
using Domain.Entities.Usuario;
using Interface.Repository.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Services.Authentication;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IUserRepository _repository;

        public HomeController(IUserRepository userRepository)
        {
            _repository = userRepository ?? throw new
                ArgumentException(nameof(userRepository));
        }

        /// <summary>
        ///     EndPoint fazer login na aplicação
        /// </summary>
        ///  <remarks>
        ///       End point que utiliza o usuarioLoginViewModel como parametro para fazer login na aplicação
        ///  </remarks>
        /// <returns>
        ///     Retorna uma token para fazer a autenticação
        /// </returns>
        /// <response code="200"> Retornar token </response>
        /// <response code="404"> Usuário ou senha invalidos </response>
        /// <response code="400"> Campos usuario ou senha precisam ser preenchidos </response>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UsuarioLoginViewModel model)
        {
            // Recupera o usuário
            var user = _repository.GetUsuario(model.UserName, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
