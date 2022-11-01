using System.ComponentModel.DataAnnotations;

namespace Libreria.Domain;


public class Libro
{
    [Required]
    public int Id {get;set;}
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nombre {get;set;}
    public DateTime? FechaPublicacion {get;set;}

    // Dependencias
    [Required]
    public int AutorId {get;set;}
    public virtual Autor Autor {get;set;}

    [Required]
    public int EditorialId {get;set;}
    public virtual Editorial Editorial {get;set;}


}




