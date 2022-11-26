using Domain.Data.ViewModels.Criacao;
using Domain.Entities.Usuario;
using KitandaAPI.Data.ViewModels;

namespace Interface.Repository.User
{
    public interface IUserRepository
    {
        Usuario? GetUsuario(string username, string password);
        Task CriarUsuario(ClienteViewModel viewModel);
        void ComprarProduto(Guid produtoId, string token);
        Usuario ObterUsuarioLogado();
        List<ProdutoGridViewModel> ExibirComprados(string token);
    }
}
