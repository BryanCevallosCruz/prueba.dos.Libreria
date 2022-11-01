using System.ComponentModel.DataAnnotations;
using Libreria.Domain;
namespace Libreria.Application
{
    public class EditorialCrearActualizarDto
    {
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nombre {get;set;}
    }
}