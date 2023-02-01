using System.ComponentModel;
using WishListBooks.Models.Entities;

namespace WishListBooks.Service.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria> FindById(int id);
        Task<int> Save(Categoria categoria);
        Task<int> Delete(int id);
        Task<int> Update(Categoria categoria);

    }
}
