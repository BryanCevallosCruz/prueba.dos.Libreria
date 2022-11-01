using System.ComponentModel.DataAnnotations;
using Libreria.Domain;
namespace Libreria.Application
{
    public class AutorCrearActualizarDto
    {
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nombre {get;set;}
    }
}