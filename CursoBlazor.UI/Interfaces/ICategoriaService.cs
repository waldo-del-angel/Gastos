using CursoBlazor.Models;

namespace CursoBlazor.UI.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria> GetCategoria(int id);
        Task SaveCategoria(Categoria categoria);
        Task DeleteCategoria(int id);
    }
}
