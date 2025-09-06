using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_biblioteca.database;
using api_biblioteca.models;
using Microsoft.EntityFrameworkCore;

namespace api_biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly Db _context;

        public LivrosController(Db context)
        {
            _context = context;
        }

        //GET : api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livros>>> GetLivro()
        {
            return await _context.Livros.ToListAsync();
        }

        //GET : api/Livros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livros>> GetLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
                return NotFound();
            return livro;
        }

        [HttpPost]
        public async Task<ActionResult<Livros>> PostLivro(Livros livro)
        {
            Livros insert = new Livros();

            insert.Titulo = livro.Titulo;
            insert.Autor = livro.Autor;
            insert.Ano_Publicacao = livro.Ano_Publicacao;
            insert.Genero = livro.Genero;
            insert.Editora = livro.Editora;
            _context.Livros.Add(insert);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(insert), new { id = livro.Id }, livro);

        }
        //PUT : api/Livros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livros Livro)
        {
            if (id != Livro.Id)
                return BadRequest();
            _context.Entry(Livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
                return NotFound();
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
