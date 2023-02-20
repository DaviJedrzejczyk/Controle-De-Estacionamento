using Entities;
using WebApi.Models;

namespace WebApi.Profile
{
    public class CarroProfile : AutoMapper.Profile
    {
        public CarroProfile()
        {
            CreateMap<CarroInsertEntradaViewModel, Carro>();
            CreateMap<Carro, CarroInsertEntradaViewModel>();

            CreateMap<CarroSaidaSelectViewModel, Carro>();
            CreateMap<Carro, CarroSaidaSelectViewModel>();

            CreateMap<CarroListViewModel, Carro>();
            CreateMap<Carro,CarroListViewModel>();

            CreateMap<FilterDateViewModel, SaidasCarro>();
            CreateMap<SaidasCarro, FilterDateViewModel>()
                .ForPath(c => c.HorarioEntrada,
                                x => x.MapFrom(src => src.Carro.HorarioEntrada))
                .ForPath(c => c.Placa,
                                x => x.MapFrom(src => src.Carro.Placa));

            CreateMap<CarroSelectViewModel, SaidasCarro>();
            CreateMap<SaidasCarro, CarroSelectViewModel>()
                .ForPath(c => c.Carro.Placa,
                            x => x.MapFrom(src => src.Carro.Placa))
                .ForPath(c => c.Carro.HorarioEntrada,
                            x => x.MapFrom(src => src.Carro.HorarioEntrada));
        }
    }
}
