using api_biblioteca.database;
using api_biblioteca.models;
using api_biblioteca.Services.AutorService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api_biblioteca.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly Db _context;
        public AutorService(Db context)
        {
            _context = context;
        }

        public async Task<ReponseModel<Autores>> BuscarAutorPorId(int Id)
        {
            ReponseModel<Autores> response = new ReponseModel<Autores>();
            try
            {
                var autor = await _context.Autores.FindAsync(Id);
                if (autor == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }
                response.Dados = autor;
                response.Mensagem = "Autor encontrado com sucesso";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Dados = null;
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ReponseModel<Autores>> BuscarAutorPorIdLivro(int Idlivro)
        {
            throw new NotImplementedException();
        }

        public async Task<ReponseModel<List<Autores>>> ListarAutores()
        {
            ReponseModel<List<Autores>> response = new ReponseModel<List<Autores>>();
            try
            {
                var autores = await _context.Autores.ToListAsync();

                response.Dados = autores;
                response.Mensagem = "Autores listados com sucesso";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Dados = null;
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}


