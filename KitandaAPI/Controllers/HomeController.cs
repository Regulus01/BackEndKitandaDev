using Domain.Data.ViewModels;
using Domain.Data.ViewModels.Criacao;
using Domain.Entities.Usuario;
using Interface.Repository.User;
using KitandaAPI.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KitandaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _repository;

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
            user.InformeSennha("");

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
        
        /// <summary>
        /// EndPoint que obtem o dados do cliente logado
        /// </summary>
        ///  <remarks>
        ///       End point que retorna os dados do cliente logado
        ///  </remarks>
        ///<returns>Nome e endereco do usuário logado</returns>
        ///<response code="200"> Usuário está logado </response>
        ///<response code="401"> Não autenticado </response>
        [HttpGet]
        [Route("ObterUsuario")]
        [Authorize]
        public Usuario? ObterUsuarioLogado()
        {
            return _repository.ObterUsuarioLogado();
        }

        /// <summary>
        ///     EndPoint que cria um usuário
        /// </summary>
        ///<remarks>
        ///     EndPoint utilizado para criar um usuário para logar na aplicação
        /// </remarks>>
        /// <param name="usuario"></param>
        /// <returns>Sem retorno</returns>
        ///<response code="200"> Usuário criado com sucesso </response>
        [HttpPost]
        [Route("CriarUsuario")]
        [AllowAnonymous]
        public async Task<ActionResult<ClienteViewModel>> CriarUsuario([FromBody] ClienteViewModel usuario)
        {
            await _repository.CriarUsuario(usuario);
            return Ok();
        }

        /// <summary>
        ///     EndPoint para o usuario logado comprar um produto
        /// </summary>
        ///<remarks>
        ///     EndPoint utilizados por clientes para comprar um produto
        /// </remarks>>
        /// <param name="idProduto"></param>
        /// <param name="quantidade"></param>
        /// <returns>Sem retorno</returns>
        ///<response code="200"> Produto comprado </response>
        [HttpPost]
        [Route("ComprarProduto")]
        public async Task<ActionResult> ComprarProduto(Guid idProduto, int quantidade)
        {
            _repository.ComprarProduto(idProduto, quantidade);
            
            return Ok();
        }
        
    }
}
