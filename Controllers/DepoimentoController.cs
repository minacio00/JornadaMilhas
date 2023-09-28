using AutoMapper;
using JornadaMilhas.Data;
using JornadaMilhas.Data.Dtos;
using JornadaMilhas.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult GetDepoimentos()
        {
            List<Depoimento> depoimentos = _context.Depoimentos.ToList();
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

            return new ObjectResult(depoimento) {
                StatusCode = 201
            };
        }
    }
}