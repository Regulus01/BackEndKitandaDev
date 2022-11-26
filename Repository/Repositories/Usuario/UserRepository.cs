using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Domain.Data.ViewModels.Criacao;
using Interface.Repository.User;
using Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using KitandaAPI.Data.ViewModels;
using KitandaAPI.Services.Authentication;
using Repository.Common;

namespace Repository.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private ProdutoRepository _repository;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Usuario? GetUsuario(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
                return null;
            
            var usuarioLogin = _context.Usuario.Include(x => x.Cliente)
                                .FirstOrDefault(x => x.UserName == username && 
                                                     x.Password == password);
            
            
            return usuarioLogin;
        }

        public Usuario ObterUsuarioLogado()
        {
            var usuarioId = AuthenticatedUser.ObterUsuarioLogado();

            var usuario = _context.Usuario.Include(x => x.Cliente).FirstOrDefault(x => x.Id == usuarioId);
            
            
            return usuario;
        }
        
        private string ObterCliente(string tokenUsuario)
        {
            var tokenString = "Bearer " + tokenUsuario;

            var jwtEncodedString = tokenString.Substring(7);

            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);

            var guidUsuario = token.Claims.First(c => c.Type == "nameid").Value;

            return guidUsuario;
        }

        public void ComprarProduto(Guid produtoId, string token)
        {
            var usuarioGuid = new Guid(ObterCliente(token));
            
            var produto = _context.Produtos
                .Include(x => x.Categoria)
                .Include(y => y.Imagens)
                .OrderBy(x => x.Quantidade)
                .FirstOrDefault(x => x.Id == produtoId);
            
            var usuario = _context.Usuario.Include(x => x.Cliente)
                .Include(x => x.Cliente.Produtos)
                .FirstOrDefault(x => x.Id == usuarioGuid);
            
            if(produto != null)
                usuario.Cliente.ComprarProduto(produto);

            _context.Update(usuario.Cliente.Produtos);
            _context.SaveChanges();
        }

        public List<ProdutoGridViewModel> ExibirComprados(string token)
        {
            var usuarioGuid = new Guid(ObterCliente(token));
            
            var usuario = _context.Usuario.Include(x => x.Cliente).Include(x => x.Cliente.Produtos)
                .FirstOrDefault(x => x.Id == usuarioGuid);

            var compras = usuario.Cliente.Produtos;
            
            return _mapper.Map<List<ProdutoGridViewModel>>(compras);
        }

        public async Task CriarUsuario(ClienteViewModel viewModel)
        {
            if (viewModel == null)
                throw new NullReferenceException("Não há informações para serem cadastradas");
            
            var usuario = _mapper.Map<Usuario>(viewModel);
            usuario.InformeRole("Cliente");
            usuario.InfomeCriacao(DateTime.UtcNow);
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            
            var cliente = _mapper.Map<Cliente>(viewModel);
            cliente.InformeUsuarioId(usuario.Id);
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
