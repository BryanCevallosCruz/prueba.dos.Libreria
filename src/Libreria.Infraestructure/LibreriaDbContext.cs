using Libreria.Domain;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infraestructure;

public class LibreriaDbContext:DbContext
{

    //Agregar sus entidades
    public DbSet<Autor> Autores {get;set;}
    public DbSet<Editorial> Editoriales {get;set;}
    public DbSet<Libro> Libros {get;set;}
    public string DbPath { get; set; }

    public LibreriaDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "libreria.db");
 
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

} 
