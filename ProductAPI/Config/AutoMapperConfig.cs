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
                    .ForMember(x => x.CategoriaNome, opt => opt.MapFrom(src => src.Nome));
                config.CreateMap<ProdutoGridViewModel, Produto>();

                config.CreateMap<CategoriaProduto, CategoriaProdutoGridViewModel>().ReverseMap();
                config.CreateMap<ImagemProduto, ImagemProdutoGridViewModel>().ReverseMap();

                config.CreateMap<ProdutoViewModel, Produto>();
            });

            return autoMapperConfig;
        }
    }
}
