
using Libreria.Domain;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infraestructure;

public class LibroRepository : EfRepository<Libro>, ILibroRepository
{
    public LibroRepository(LibreriaDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteNombre(string nombre) {

        var resultado = await this._context.Set<Libro>()
                       .AnyAsync(x => x.Nombre.ToUpper() == nombre.ToUpper());

        return resultado;
    }

    public async Task<bool> ExisteNombre(string nombre, int idExcluir)  {

        var query =  this._context.Set<Libro>()
                       .Where(x => x.Id != idExcluir)
                       .Where(x => x.Nombre.ToUpper() == nombre.ToUpper())
                       ;

        var resultado = await query.AnyAsync();

        return resultado;
    }

    
}