using api_biblioteca.models;

namespace api_biblioteca.Services.AutorService
{
    public interface IAutorInterface
    {
        Task<ReponseModel<List<Autores>>> ListarAutores();
        Task<ReponseModel<Autores>> BuscarAutorPorId(int Id);
        Task<ReponseModel<Autores>> BuscarAutorPorIdLivro(int Idlivro);
    }
}
