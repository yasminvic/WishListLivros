using WishListBooks.Models.Entities;
using WishListBooks.Repository;
using WishListBooks.Service.Interfaces;

namespace WishListBooks.Service.Implements
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<User> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<User> FindByLogin(string login)
        {
            return await _repository.FindUserByLogin(login);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<int> Save(User user)
        {
            return await _repository.Save(user);
        }

        public async Task<int> Update(User user)
        {
            return await _repository.Update(user);
        }
    }
}
