using JuegoImpostor.Models;
using JuegoImpostor.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JuegoImpostor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller(ILogger<Controller> logger) : ControllerBase
    {
        private readonly ILogger<Controller> _logger = logger;

        [HttpGet]
        [Route("GetJuegoImpostor")]
        public Task<ResponseModel> GetJuegoImpostor()
        {
            return ResponseService.Response("Juego impostor", null, null, HttpStatusCode.OK);
        }
    }
}
