using Domain.Data.ViewModels.Criacao;
using Domain.Entities.Usuario;

namespace Interface.Repository.User
{
    public interface IUserRepository
    {
        Usuario? GetUsuario(string username, string password);
        Task CriarUsuario(ClienteViewModel viewModel);
    }
}
