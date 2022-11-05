using AutoMapper;
using Domain.Data.ViewModels.Criacao;
using Interface.Repository.User;
using Domain.Entities.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repository.Common;

namespace Repository.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _context;
        private IMapper _mapper;
        
        private readonly UserManager<Usuario> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(ApplicationDbContext context, IMapper mapper,
            UserManager<Usuario> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Usuario? GetUsuario(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
                return null;
            
            var usuarioLogin = _context.Usuario.FirstOrDefault(x => x.UserName == username && 
                                                                    x.Password == password);
            
            
            return usuarioLogin;
        }

        public async Task<Usuario> GetUser()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return user;
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
