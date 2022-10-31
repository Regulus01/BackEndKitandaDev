using AutoMapper;
using Domain.Data.ViewModels.Criacao;
using Interface.Repository.User;
using Domain.Entities.Usuario;
using Repository.Common;

namespace Repository.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _context;
        //private IMapper _mapper;
        private Usuario _usuarioLogado;

        public UserRepository(ApplicationDbContext context, AuthenticatedUser user)
        {
            _context = context;
        }

        public Usuario? GetUsuario(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
                return null;
            
            var usuarioLogin = _context.Usuario.FirstOrDefault(x => x.UserName == username && 
                                                                    x.Password == password);
            
            if (usuarioLogin != null)
                _usuarioLogado = usuarioLogin;
            
            return usuarioLogin;
        }

        public Usuario ObterUsuarioLogado()
        {
            return _usuarioLogado;
        }
        public Cliente CriarUsuario(ClienteViewModel viewModel)
        {
            return null;
        }
    }
}
