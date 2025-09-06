namespace api_biblioteca.models
{
    public class Livros
    {
        public int Id { get; set; }
        public string? Titulo { get; set; } = string.Empty;
        public int Ano_Publicacao { get; set; }
        public string? Genero { get; set; } = string.Empty;
        public string? Editora { get; set; } = string.Empty;
        public Autores Autor { get; set; }

    }
}
