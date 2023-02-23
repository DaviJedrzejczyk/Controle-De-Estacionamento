using AutoMapper;
using Entities;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Shared;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class CarroController : Controller
    {
        private readonly ICarroService _carroService;
        private readonly ISaidaCarroService _saida;
        private readonly IMapper _mapper;
        public CarroController(ICarroService service, IMapper mapper, ISaidaCarroService saida)
        {
            _carroService = service;
            _mapper = mapper;
            _saida = saida;
        }
        [HttpGet("All-Entrances")]
        public async Task<IActionResult> Index()
        {
            DataResponse<Carro> dataResponse = await _carroService.GetAllWithoutExits();
            if (!dataResponse.HasSuccess)
            {
                return BadRequest();
            }
            List<CarroSaidaSelectViewModel> carros = _mapper.Map<List<CarroSaidaSelectViewModel>>(dataResponse.Itens);
            return Ok(carros);
        }

        [HttpGet]
        public IActionResult InsertEntrada()
        {
            return Ok();
        }
        [HttpPost("Inserir-Entrada")]
        public async Task<IActionResult> InsertEntrada(CarroInsertEntradaViewModel viewModel)
        {
            Carro carro = _mapper.Map<Carro>(viewModel);
            Response response = await _carroService.InsertEntrada(carro);
            if (response.HasSuccess)
            {

                return Ok();
            }
            return BadRequest(response.Message);
        }
        [HttpGet("Inserir-Saida")]
        public async Task<IActionResult> InserirSaida(int id)
        {
            SingleResponse<Carro> single = await _carroService.GetById(id);
            if (!single.HasSuccess)
            {
                return BadRequest(single.Message);
            }
            SaidasCarro saidasCarro = new()
            {
                HorarioSaida = DateTime.Now,
                CarroID = single.Item.ID,
                Carro = single.Item
            };
            Response response = await _saida.Insert(saidasCarro);
            if (!response.HasSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok();
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string? searchString)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchString))
                {
                    DataResponse<Carro> dataResponse = await _carroService.SearchItem(searchString);
                    List<CarroListViewModel> carroListViewModels = _mapper.Map<List<CarroListViewModel>>(dataResponse.Itens);
                    return Ok(carroListViewModels);
                }
                else
                {
                    DataResponse<Carro> dataResponse = await _carroService.SearchItem(searchString);
                    List<CarroListViewModel> carroListViewModels = _mapper.Map<List<CarroListViewModel>>(dataResponse.Itens);
                    if (dataResponse.Itens.Any())
                    {
                        return Ok(carroListViewModels);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            

        }
        [HttpPost("Filter-Date")]
        public async Task<IActionResult> FilterDate(FilterDateViewModel filterDateViewModel)
        {
            DataResponse<SaidasCarro> single = await _saida.FilterData(filterDateViewModel.HorarioEntrada, filterDateViewModel.HorarioSaida);
            if (!single.HasSuccess)
            {
                return BadRequest(single.Message);
            }
            List<FilterDateViewModel> filterDateViewModels = _mapper.Map<List<FilterDateViewModel>>(single.Itens);

            return Ok(filterDateViewModels);
        }

    }
}
