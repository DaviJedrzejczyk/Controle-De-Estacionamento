using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Shared;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class HomeController : Controller
    {
        private readonly ISaidaCarroService _saida;
        private readonly IMapper _mapper;
        public HomeController(ISaidaCarroService saida, IMapper mapper)
        {
            this._saida = saida;
            this._mapper = mapper;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            DataResponse<SaidasCarro> data = await _saida.GetAll();
            if (!data.HasSuccess)
            {
                return BadRequest(data.Message);
            }
            return Ok(data.Itens);
        }
       

    }
}
