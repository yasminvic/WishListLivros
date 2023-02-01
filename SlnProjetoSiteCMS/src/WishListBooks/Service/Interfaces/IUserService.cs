using WishListBooks.Models.Entities;

namespace WishListBooks.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> FindById(int id);
        Task<User> FindByLogin(string login);
        Task<int> Save(User user);
        Task<int> Delete(int id);
        Task<int> Update(User user);
    }
}
