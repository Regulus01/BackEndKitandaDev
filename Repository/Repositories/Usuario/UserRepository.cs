using AutoMapper;
using Domain.Data.ViewModels.Criacao;
using Interface.Repository.User;
using Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
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

        public Usuario? ObterUsuarioLogado()
        {
            var usuarioId = AuthenticatedUser.ObterUsuarioLogado();

            var usuario = _context.Usuario.Include(x => x.Cliente).FirstOrDefault(x => x.Id == usuarioId);
            
            return usuario;
        }

        public void ComprarProduto(Guid produtoId, int quantidade)
        {
            var usuario = ObterUsuarioLogado();
            
            var produto = _context.Produtos
                .Include(x => x.Categoria)
                .Include(y => y.Imagens)
                .OrderBy(x => x.Quantidade)
                .FirstOrDefault(x => x.Id == produtoId);
            
            if (produto is { Quantidade: 0 })
            {
                return;
            }

            if (produto != null)
            {
                usuario.Cliente.ComprarProduto(produto.Nome);
                produto.RemoverQuantidade(quantidade);
                produto.InformarVenda(quantidade);
            }

            _context.Update(produto);
            _context.Update(usuario);
            _context.SaveChanges();
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
