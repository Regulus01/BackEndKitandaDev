using AutoMapper;
using Domain.Data.ViewModels.Criacao;
using Domain.Entities;
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
                    .ForMember(x => x.CategoriaNome, opt => opt.MapFrom(src => src.Categoria.Nome));
                config.CreateMap<ProdutoGridViewModel, Produto>();

                config.CreateMap<ProdutoViewModel, ImagemProduto>()
                    .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Imagem.Nome))
                    .ForMember(x => x.LinkImagem, opt => opt.MapFrom(src => src.Imagem.LinkImagem));
                
                config.CreateMap<CategoriaProduto, CategoriaProdutoGridViewModel>().ReverseMap();
                config.CreateMap<ImagemProduto, ImagemProdutoGridViewModel>().ReverseMap();

                config.CreateMap<ProdutoViewModel, Produto>();
            });

            return autoMapperConfig;
        }
    }
}
