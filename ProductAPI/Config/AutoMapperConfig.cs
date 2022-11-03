using AutoMapper;
using Domain.Data.ViewModels.Criacao;
using Domain.Entities;
using Domain.Entities.Usuario;
using ProductAPI.Data.ViewModels;

namespace ProductAPI.Config
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Produto, ProdutoGridViewModel>()
                    .ForMember(x => x.CategoriaNome, opt => opt.MapFrom(src => src.Categoria.Nome))
                    .ForMember(x => x.ProdutoId, opt => opt.MapFrom(src => src.Id));
                config.CreateMap<ProdutoGridViewModel, Produto>();

                config.CreateMap<ProdutoViewModel, ImagemProduto>()
                    .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Imagem.Nome))
                    .ForMember(x => x.LinkImagem, opt => opt.MapFrom(src => src.Imagem.LinkImagem));
                
                config.CreateMap<CategoriaProduto, CategoriaProdutoGridViewModel>().ReverseMap();
                config.CreateMap<ImagemProduto, ImagemProdutoGridViewModel>().ReverseMap();

                config.CreateMap<ProdutoViewModel, Produto>();

                config.CreateMap<ClienteViewModel, Usuario>()
                    .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Usuario.UserName))
                    .ForMember(x => x.Password, opt => opt.MapFrom(src => src.Usuario.Password));

                config.CreateMap<ClienteViewModel, Cliente>()
                    .ForMember(x => x.Cpf, opt => opt.MapFrom(src => src.Cpf))
                    .ForMember(x => x.NomeCliente, opt => opt.MapFrom(src => src.NomeCliente))
                    .ForMember(x => x.Telefone, opt => opt.MapFrom(src => src.Telefone));
            });

            return autoMapperConfig;
        }
    }
}
