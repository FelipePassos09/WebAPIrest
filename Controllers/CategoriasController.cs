using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProduto()
        {
            try
            {
                throw new DataMisalignedException();
                return _context.Categorias.AsNoTracking().Include(prod => prod.Produtos).ToList();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao executar sua solicitação.");
            }

            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _context.Categorias.AsNoTracking().ToList();
            try 
            {
                if (categorias is null)
                {
                    return NotFound("Não há categorias cadastradas.");
                }

                return categorias;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao executar sua solicitação.");
            }
            
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(cat => cat.CategoriaId == id);
            if(categoria is null)
            {
                return NotFound("Categoria não localizada.");
            }

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            if(categoria is null)
            {
                return BadRequest("Categoria não pode ser vazio.");
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId}, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Categoria> Put(int id, Categoria categoria)
        {
            if(categoria is null)
            {
                return BadRequest("Categoria não pode ser vazio");
            }

            _context.Categorias.Entry(categoria).State = EntityState.Modified;
            //_context.Categorias.Update(categoria);//
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(cat => cat.CategoriaId == id);
            if(categoria is null)
            {
                return NotFound("Categoria não encontrada.");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }

    }
}
