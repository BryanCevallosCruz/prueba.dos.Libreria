using System.ComponentModel.DataAnnotations;

namespace Libreria.Domain;


public class Autor
{
    [Required]
    public int Id {get;set;}
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nombre {get;set;}

}




