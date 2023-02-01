using Microsoft.EntityFrameworkCore;
using WishListBooks.Models;
using WishListBooks.Models.Entities;

namespace WishListBooks.Repository
{
    public class CategoriaRepository
    {
        private readonly ContextoDatabase _context;

        public CategoriaRepository(ContextoDatabase context)
        {
            _context = context;
        }

        public async Task<int> Delete(int id)
        {
            var categoria = await _context.FindAsync<Categoria>(id);
            _context.Remove(categoria);
            return await _context.SaveChangesAsync();
        }

        public async Task<Categoria> FindById(int id)
        {
            return await _context.FindAsync<Categoria>(id);
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<int> Save(Categoria categoria)
        {
            _context.Add(categoria);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Categoria categoria)
        {
            _context.Update(categoria);
            return await _context.SaveChangesAsync();
        }
    }
}
