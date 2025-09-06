using api_biblioteca.models;
using api_biblioteca.Services.AutorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("BuscarAutores")]
        public async Task<ActionResult<ReponseModel<List<Autores>>>> BuscarAutores()
        {
            var response = await _autorInterface.ListarAutores();
            if (response.Dados == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("BuscarAutorPorId/{IdAutor}")]
        public async Task<ActionResult<ReponseModel<Autores>>> BuscarAutorPorId(int Id)
        {
            var response = await _autorInterface.BuscarAutorPorId(Id);
            if (response.Dados == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


    }   

    }
