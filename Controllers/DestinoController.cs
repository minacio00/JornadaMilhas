
using AutoMapper;
using JornadaMilhas.Data;
using JornadaMilhas.Data.Dtos;
using JornadaMilhas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Controllers
{
    [ApiController]
    [Route("/destinos")]
    [Consumes("application/json")]
    public class DestinoController : ControllerBase
    {
        private readonly JornadaMilhasContext _context; 
        private readonly IMapper _mapper;
        public DestinoController(JornadaMilhasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDestinos()
        {
            List<Destino> destinos = await _context.Destinos.ToListAsync();
            return Ok(destinos);
        }

        [HttpGet("{id}")]
        public IActionResult GetDestinoById(int id)
        {
            Destino destino = _context.Destinos.FirstOrDefault(d => d.Id == id);
            if (destino == null)
            {
                return NotFound();
            }

            var destinoDto = _mapper.Map<ReadDestinoDTO>(destino);
            return Ok(destinoDto);
        }
        [HttpGet("search")]
        public IActionResult GetDestinoByName([FromQuery] string nome)
        {
            Console.WriteLine(nome);
            var destinos = _context.Destinos.Where(d => d.Nome == nome).ToList();
            if (destinos == null)
            {
                return NotFound(new {mensagem = "Nenhum destino foi encontrado"});
            }
            List<ReadDestinoDTO> destinosDto = _mapper.Map<List<ReadDestinoDTO>>(destinos);
            return Ok(destinosDto);
        }

        [HttpPost]
        public IActionResult CreateDestino([FromBody] CreateDestinoDto destinoDto)
        {
            Destino destino = _mapper.Map<Destino>(destinoDto);
            _context.Destinos.Add(destino);
            _context.SaveChanges();

            return new ObjectResult(destino)
            {
                StatusCode = 201
            };
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDestino([FromBody] CreateDestinoDto destinoDto, int id)
        {
            var destino = _context.Destinos.FirstOrDefault(d => d.Id == id);
            if (destino == null)
            {
                return NotFound();
            }

            _mapper.Map(destinoDto, destino);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDestino(int id)
        {
            var destino = _context.Destinos.FirstOrDefault(d => d.Id == id);
            if (destino == null)
            {
                return NotFound();
            }

            _context.Destinos.Remove(destino);
            _context.SaveChanges();

            return NoContent();
        }

    }
}