using WishListBooks.Models.Entities;
using WishListBooks.Repository;
using WishListBooks.Service.Interfaces;

namespace WishListBooks.Service.Implements
{
    public class LivroService : ILivroService
    {
        private readonly LivroRepository _repository;

        public LivroService(LivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Livro> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<IEnumerable<Livro>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<int> Save(Livro livro)
        {
            return await _repository.Save(livro);
        }

        public async Task<int> Update(Livro livro)
        {
            return await _repository.Update(livro);
        }
    }
}
