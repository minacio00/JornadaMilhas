
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