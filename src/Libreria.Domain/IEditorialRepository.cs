namespace Libreria.Domain;

public interface IEditorialRepository :  IRepository<Editorial> {

    Task<bool> ExisteNombre(string nombre);

    Task<bool> ExisteNombre(string nombre, int idExcluir);
}
