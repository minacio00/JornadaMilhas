using AutoMapper;
using JornadaMilhas.Data;
using JornadaMilhas.Data.Dtos;
using JornadaMilhas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Controllers
{
    [ApiController]
    [Route("/depoimentos")]
    [Consumes("application/json")]
    public class DepoimentoController : ControllerBase
    {

        private readonly JornadaMilhasContext _context;
        private readonly IMapper _mapper;
        public DepoimentoController(JornadaMilhasContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper; 
        }

        [HttpGet]
        public async Task<IActionResult> GetDepoimentos()
        {
            List<Depoimento> depoimentos = await _context.Depoimentos.ToListAsync();
            return Ok(depoimentos);
        }
        [HttpGet("{id}")]
        public IActionResult GetDepoimentoById(int id)
        {
            Depoimento depoimento = _context.Depoimentos.FirstOrDefault(d => d.Id == id);
            if (depoimento == null)
            {
                return NotFound();
            }
            ReadDepoimentoDto depoimentoDto = _mapper.Map<ReadDepoimentoDto>(depoimento);
            return Ok(depoimentoDto);
        }

        [HttpPost]
        public IActionResult CreateDepoimentos([FromBody] CreateDepoimentoDto depoimentoDto)
        {
            // todo: testar == null    
            Depoimento depoimento = _mapper.Map<Depoimento>(depoimentoDto);
            _context.Depoimentos.Add(depoimento);
            _context.SaveChanges();

            return new ObjectResult(depoimentoDto) {
                StatusCode = 201
            };
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDepoimento([FromBody] UpdateDepoimentoDto depoimentoDto, int id)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(d => d.Id == id);
            if (depoimento == null)
            {
                return NotFound();
            }
            _mapper.Map(depoimentoDto, depoimento);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDepoimento(int id)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(d => d.Id == id);
            if (depoimento == null)
            {
                return NotFound();
            }
            _context.Depoimentos.Remove(depoimento);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("/depoimentos-home")]
        public async Task<IActionResult> GetDepoimentosRandom()
        {
            // Todo: Sometimes it does not select 3
            var random = new Random();
            int randomOffeset = random.Next(3, await _context.Depoimentos.CountAsync()); // ??????
            List<Depoimento> depoimentos =  _context.Depoimentos
            .OrderBy(x => randomOffeset)
            .Skip(randomOffeset)
            .Take(3)
            .ToList();
            return Ok(depoimentos);
        }
    }
}