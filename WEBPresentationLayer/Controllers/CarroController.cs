using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using Newtonsoft.Json;
using System.Net.Http.Json;
using WEBPresentationLayer.Models;

namespace WEBPresentationLayer.Controllers
{
    public class CarroController : Controller
    {
        private readonly HttpClient httpClient;
        public CarroController(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7155/");
            this.httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                HttpResponseMessage message = await httpClient.GetAsync("Carro/All-Entrances");
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    List<CarroSaidaSelectViewModel> carros = JsonConvert.DeserializeObject<List<CarroSaidaSelectViewModel>>(json);
                    if (carros is null || carros.Count is 0)
                    {
                        return NotFound();
                    }
                    return View(carros);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult InserirEntrada()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InserirEntrada(CarroInsertEntradaViewModel viewModel)
        {
            try
            {
                HttpResponseMessage message = await httpClient.PostAsJsonAsync<CarroInsertEntradaViewModel>("Carro/Inserir-Entrada", viewModel);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                string json = await message.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return NotFound();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> InserirSaida(int id)
        {
            try
            {
                HttpResponseMessage message = await httpClient.GetAsync($"Carro/Inserir-Saida?id={id}");
                string json = await message.Content.ReadAsStringAsync();
                if (!message.IsSuccessStatusCode)
                {
                    return NotFound();
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Search(string? searchString)
        {
            try
            {
                HttpResponseMessage message = await httpClient.GetAsync($"Carro/Search?search={searchString}");
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    List<CarroListViewModel> carro = JsonConvert.DeserializeObject<List<CarroListViewModel>>(json);
                    if (carro is null)
                    {
                        return NotFound();
                    }
                    return View(carro);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> FilterDate(DateTime dataEntrada, DateTime dataSaida)
        {
            try
            {
                FilterDateViewModel filter = new()
                {
                    HorarioEntrada = dataEntrada,
                    HorarioSaida = dataSaida
                };
                HttpResponseMessage message = await httpClient.PostAsJsonAsync("Carro/Filter-Date", filter);
               
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    List<FilterDateViewModel> viewModels = JsonConvert.DeserializeObject<List<FilterDateViewModel>>(json);
                    if (viewModels is null)
                    {
                        return NotFound();
                    }
                    return View(viewModels);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
