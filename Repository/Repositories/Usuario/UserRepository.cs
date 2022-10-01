using Interface.Repository.User;
using Domain.Entities.Usuario;
using Repository.Common;

namespace Repository.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _context;


        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public Usuario? GetUsuario(string username, string password)
        {
            if (username != null && password != null)
            {
                var usuarioLogin = _context.Usuario.FirstOrDefault(x => x.UserName == username &&
                                                                            x.Password == password);
                return usuarioLogin;
            }
            
            return null;
            
        }
    }
}
