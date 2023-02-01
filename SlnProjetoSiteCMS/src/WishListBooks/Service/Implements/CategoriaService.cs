using WishListBooks.Models.Entities;
using WishListBooks.Repository;
using WishListBooks.Service.Interfaces;

namespace WishListBooks.Service.Implements
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _repository;

        public CategoriaService(CategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Categoria> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<int> Save(Categoria categoria)
        {
            return await _repository.Save(categoria);
        }

        public async Task<int> Update(Categoria categoria)
        {
            return await _repository.Update(categoria);
        }
    }
}
