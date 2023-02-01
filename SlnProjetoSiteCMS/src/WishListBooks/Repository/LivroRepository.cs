using Microsoft.EntityFrameworkCore;
using WishListBooks.Models;
using WishListBooks.Models.Entities;

namespace WishListBooks.Repository
{
    public class LivroRepository
    {
        private readonly ContextoDatabase _context;

        public LivroRepository(ContextoDatabase context)
        {
            _context = context;
        }

        public async Task<int> Delete(int id)
        {
            var lvr = await _context.FindAsync<Livro>(id);
            _context.Remove(lvr);
            return await _context.SaveChangesAsync();
        }

        public async Task<Livro> FindById(int id)
        {
            return await _context.Livro
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Livro>> GetAll()
        {
            return await _context.Livro
                .OrderBy(lvr => lvr.Nome)
                .Include(l => l.Categoria)
                .ToListAsync();
        }

        public async Task<int> Save(Livro livro)
        {
            _context.Add(livro);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Livro livro)
        {
            _context.Update(livro);
            return await _context.SaveChangesAsync();
        }
    }
}
