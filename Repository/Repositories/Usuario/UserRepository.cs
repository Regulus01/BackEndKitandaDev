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

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Usuario? GetUsuario(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
                return null;
            
            var usuarioLogin = _context.Usuario.FirstOrDefault(x => x.UserName == username && 
                                                                    x.Password == password);
            
            
            return usuarioLogin;
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
