using Domain.Entities.Usuario;

namespace Interface.Repository.User
{
    public interface IUserRepository
    {
        public Usuario? GetUsuario(string username, string password);
    }
}
