using System.Text.Json.Serialization;

namespace api_biblioteca.models
{
    public class Autores
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        [JsonIgnore]
        public ICollection<Livros> livros { get; set; }

    }
}
