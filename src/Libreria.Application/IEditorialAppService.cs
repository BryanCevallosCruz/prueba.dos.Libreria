using System.ComponentModel.DataAnnotations;
using Libreria.Domain;

namespace Libreria.Application;


public interface IEditorialAppService
{
    ICollection<EditorialDto> GetAll();
    Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorial);
    Task UpdateAsync (int id, EditorialCrearActualizarDto editorial);
    Task<bool> DeleteAsync(int editorialId);
}
 
 
