using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Desafio_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EsperaController : ControllerBase
    {
        [HttpGet]
        public string get()
        {
            return "ok";
        }
    }
}
