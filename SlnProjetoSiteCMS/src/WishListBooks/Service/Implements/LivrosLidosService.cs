using WishListBooks.Models.Entities;
using WishListBooks.Repository;
using WishListBooks.Service.Interfaces;

namespace WishListBooks.Service.Implements
{
    public class LivrosLidosService : ILivrosLidosService
    {
        private readonly LivrosLidosRepository _repository;

        public LivrosLidosService(LivrosLidosRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<LivrosLidos> FindById(int id)
        {
            return await _repository.FindById(id);
        }
        public async Task<IEnumerable<LivrosLidos>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<int> Save(LivrosLidos livrosLidos)
        {
            return await _repository.Save(livrosLidos);
        }

        public async Task<int> Update(LivrosLidos livrosLidos)
        {
            return await _repository.Update(livrosLidos);
        }
    }
}
