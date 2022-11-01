using System.ComponentModel.DataAnnotations;
using Libreria.Domain;

namespace Libreria.Application;

 
public class AutorDto
{
    [Required]
    public int Id {get;set;}

    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nombre {get;set;}
}

 