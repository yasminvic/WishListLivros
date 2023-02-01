using WishListBooks.Models.Entities;

namespace WishListBooks.Service.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> GetAll();
        Task<Livro> FindById(int id);
        Task<int> Save(Livro livro);
        Task<int> Delete(int id);
        Task<int> Update(Livro livro);
    }
}
