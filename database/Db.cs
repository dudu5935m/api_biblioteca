using Microsoft.EntityFrameworkCore;
using api_biblioteca.models;

namespace api_biblioteca.database
{
    public class Db : DbContext
     { 
        
         public Db(DbContextOptions<Db> options) : base(options) { }
         public DbSet<Livros> Livros { get; set; }
         public DbSet<Autores> Autores { get; set; }

    }
}
