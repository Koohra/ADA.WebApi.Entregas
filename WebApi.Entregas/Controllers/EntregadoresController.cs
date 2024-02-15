using Dados;
using Dados.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entregas.Filters;

namespace WebApi.Entregas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregadoresController : ControllerBase
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public EntregadoresController(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository;
        }
       
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_entregadorRepository.GetAll());
        }

        [HttpGet("{CPF}")]
        public IActionResult GetCpf(string cpf)
        {
            var entregador = _entregadorRepository.GetByCpf(cpf);

            if (entregador == null)
            {
                return NotFound("Entregador não encontrado");
            }
            return Ok(entregador);
        }
        [HttpPost]
        [TypeFilter(typeof(FiltroAutorizacao))]
        public IActionResult Post(Entregador entregadorRequest)
        {
            return Ok(_entregadorRepository.Add(new Entregador
            {
                Nome = entregadorRequest.Nome,
                CPF = entregadorRequest.CPF
            }));
        }
    }
}
