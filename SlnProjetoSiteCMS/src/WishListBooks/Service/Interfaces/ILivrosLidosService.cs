using System.Drawing;
using WishListBooks.Models.Entities;

namespace WishListBooks.Service.Interfaces
{
    public interface ILivrosLidosService
    {
        Task<IEnumerable<LivrosLidos>> GetAll();
        Task<LivrosLidos> FindById(int id);
        Task<int> Save(LivrosLidos livrosLidos);
        Task<int> Delete(int id);
        Task<int> Update(LivrosLidos livrosLidos);
    }
}
