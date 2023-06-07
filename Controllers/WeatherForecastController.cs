using Microsoft.AspNetCore.Mvc;

namespace ejemploPaLoPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public static List<string> frases_celebres = new List<string>
        {
        "molesto unas copillas", "no vives de ensalada", "pues ENGRASEME", "NADA PUESTO", "Me lleva la cachetada"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetSaludo")]
        public string GetSaludo()
        {
            return "Molesto unas copillas";
        }

        [HttpGet("GetFrases")]
        public List<string> GetFrases()
        {
            return frases_celebres;
        }

        [HttpGet("GetFrases/{frase}")]
        public string GetFrases([FromQuery] int frase)
        {
            return frases_celebres[frase];
        }

        [HttpDelete("DeleteFrase/{frase}")]
        public List<string> DeleteFrase([FromQuery] int frase)
        {
            frases_celebres.RemoveAt(frase);
            return frases_celebres;
        }

        [HttpPost("PostFrase")]
        public List<string> PostFrase([FromBody] Frase frase )
        {
            frases_celebres.Add(frase.frase);
            return frases_celebres;
        }
    }
}