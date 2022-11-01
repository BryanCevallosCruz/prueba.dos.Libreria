using System.ComponentModel.DataAnnotations;
using Libreria.Domain;

namespace Libreria.Application;

public interface IAutorAppService
{
    ICollection<AutorDto> GetAll();
    Task<AutorDto> CreateAsync(AutorCrearActualizarDto autor);
    Task UpdateAsync (int id, AutorCrearActualizarDto autor);
    Task<bool> DeleteAsync(int autorId);
}
 
 
