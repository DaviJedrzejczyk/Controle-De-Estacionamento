using Entities;
using WEBPresentationLayer.Models;

namespace WEBPresentationLayer.Profile
{
    public class CarroProfile : AutoMapper.Profile
    {
        public CarroProfile()
        {
            CreateMap<CarroInsertEntradaViewModel, Carro>();
            CreateMap<Carro, CarroInsertEntradaViewModel>();

            CreateMap<CarroListViewModel, Carro>();
            CreateMap<Carro, CarroListViewModel>();

            CreateMap<FilterDateViewModel, SaidasCarro>();
            CreateMap<SaidasCarro, FilterDateViewModel>()
                .ForPath(c => c.HorarioEntrada,
                                x => x.MapFrom(src => src.Carro.HorarioEntrada))
                .ForPath(c => c.Placa,
                                x => x.MapFrom(src => src.Carro.Placa));

            CreateMap<CarroSelectViewModel, SaidasCarro> ();
            CreateMap<SaidasCarro, CarroSelectViewModel>()
                .ForPath(c => c.Carro.Placa,
                            x => x.MapFrom(src => src.Carro.Placa))
                .ForPath(c => c.Carro.HorarioEntrada,
                            x => x.MapFrom(src => src.Carro.HorarioEntrada));
        }
    }
}
