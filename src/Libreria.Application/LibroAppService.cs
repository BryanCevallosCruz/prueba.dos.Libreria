using System.ComponentModel.DataAnnotations;
using Libreria.Domain;

namespace Libreria.Application;

public class LibroAppService : ILibroAppService
{
    private readonly ILibroRepository repository;
    //private readonly IUnitOfWork unitOfWork;

    public LibroAppService(ILibroRepository repository)
    {
        this.repository = repository;
        //this.unitOfWork = unitOfWork;
    }

    public async Task<LibroDto> CreateAsync(LibroCrearActualizarDto libroDto)
    {
        //Reglas Validaciones... 
        var existeNombreLibro = await repository.ExisteNombre(libroDto.Nombre);
        if (existeNombreLibro)
        {
            throw new ArgumentException($"Ya existe un libro con el nombre {libroDto.Nombre}");
        }
        //Mapeo Dto => Entidad
        var libro = new Libro();
        libro.Nombre = libroDto.Nombre;
        libro.FechaPublicacion = libroDto.FechaPublicacion;
        libro.AutorId = libroDto.AutorId;
        libro.EditorialId = libroDto.EditorialId;

        //Persistencia objeto
        libro = await repository.AddAsync(libro);
        //await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var libroCreado = new LibroDto();
        libroCreado.Nombre = libro.Nombre;
        libroCreado.Id = libro.Id;
        libroCreado.AutorId = libro.AutorId;
        libroCreado.EditorialId = libro.EditorialId;

        return libroCreado;
    }

    public async Task UpdateAsync(int id, LibroCrearActualizarDto libroDto)
    {
        var libro = await repository.GetByIdAsync(id);
        if (libro == null)
        {
            throw new ArgumentException($"El libro con el id: {id}, no existe");
        }

        var existeNombreLibro = await repository.ExisteNombre(libroDto.Nombre, id);
        if (existeNombreLibro)
        {
            throw new ArgumentException($"Ya existe un libro con el nombre {libroDto.Nombre}");
        }

        //Mapeo Dto => Entidad
        libro.Nombre = libroDto.Nombre;
        libro.FechaPublicacion = libroDto.FechaPublicacion;
        libro.AutorId = libroDto.AutorId;
        libro.EditorialId = libroDto.EditorialId;

        //Persistencia objeto
        await repository.UpdateAsync(libro);
        //await unitOfWork.SaveChangesAsync();

        return;
    }

    public async Task<bool> DeleteAsync(int libroId)
    {
        //Reglas Validaciones... 
        var libro = await repository.GetByIdAsync(libroId);
        if (libro == null)
        {
            throw new ArgumentException($"El libro con el id: {libroId}, no existe");
        }

        repository.Delete(libro);
        //await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<LibroDto> GetAll()
    {
        var consulta = repository.GetAllIncluding(x => x.Autor,
                                                x => x.Editorial);

        var listaLibroDto = from x in consulta
                            select new LibroDto()
                                {
                                    Id = x.Id,
                                    Nombre = x.Nombre,
                                    FechaPublicacion = x.FechaPublicacion,
                                    AutorId = x.AutorId,
                                    Autor = x.Autor,
                                    EditorialId = x.EditorialId,
                                    Editorial = x.Editorial

                                };
                            
        return listaLibroDto.ToList();
    }

}