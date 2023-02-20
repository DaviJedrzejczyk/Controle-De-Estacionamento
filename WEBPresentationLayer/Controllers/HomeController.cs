using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using WEBPresentationLayer.Models;

namespace WEBPresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;
        public HomeController(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7155/");
            this.httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                HttpResponseMessage mesasge = await httpClient.GetAsync("Home/Index");
                if (mesasge.IsSuccessStatusCode)
                {
                    string json = await mesasge.Content.ReadAsStringAsync();
                    List<CarroSelectViewModel> carros = JsonConvert.DeserializeObject<List<CarroSelectViewModel>>(json);
                    return View(carros);
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