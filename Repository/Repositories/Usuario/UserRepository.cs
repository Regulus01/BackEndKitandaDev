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
        private IMapper _mapper;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public Usuario? GetUsuario(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
                return null;
            
            var usuarioLogin = _context.Usuario.FirstOrDefault(x => x.UserName == username &&
                                                                    x.Password == password);
            return usuarioLogin;

        }

        public Cliente CriarUsuario(ClienteViewModel viewModel)
        {
            return null;
        }
    }
}
