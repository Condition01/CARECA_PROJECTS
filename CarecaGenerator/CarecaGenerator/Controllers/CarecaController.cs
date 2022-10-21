using CarecaGenerator.Models;
using CarecaGenerator.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarecaGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarecaController : ControllerBase, ICarecaController
    {
        private readonly ILogger<CarecaController> _logger;
        private readonly ICarecaService _carecaService;

        public CarecaController(ILogger<CarecaController> logger, ICarecaService carecaService)
        {
            _logger = logger;
            _carecaService = carecaService;
        }

        [HttpGet(Name = "GetCareca")]
        public Careca GetCareca()
        {
            var careca = _carecaService.GetCareca();

            var instance = Environment.GetEnvironmentVariable("INSTANCE");

            if(instance != null)
            {
                careca.Instance = instance;
            }

            return careca;
        }
    }
}