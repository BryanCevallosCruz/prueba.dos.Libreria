using System.ComponentModel.DataAnnotations;
using Libreria.Domain;
namespace Libreria.Application
{
    public class LibroCrearActualizarDto
    {
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nombre {get;set;}
        
    public DateTime? FechaPublicacion {get;set;}

    // Dependencias
    [Required]
    public int AutorId {get;set;}

    [Required]
    public int EditorialId {get;set;}

    }
}