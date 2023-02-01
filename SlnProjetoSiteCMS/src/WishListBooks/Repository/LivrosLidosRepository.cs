using Microsoft.EntityFrameworkCore;
using System;
using WishListBooks.Models;
using WishListBooks.Models.Entities;

namespace WishListBooks.Repository
{
    public class LivrosLidosRepository
    {
        private readonly ContextoDatabase _context;

        public LivrosLidosRepository(ContextoDatabase context)
        {
            _context = context;
        }

        public async Task<int> Delete(int id)
        {
            var lvrLido = await _context.FindAsync<LivrosLidos>(id);
            _context.Remove(lvrLido);
            return await _context.SaveChangesAsync();
        }

        public async Task<LivrosLidos> FindById(int id)
        {
            return await _context.LivrosLidos
                .Include(l => l.Livro)
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<LivrosLidos>> GetAll()
        {
            return await _context.LivrosLidos
                .OrderBy(lvrLidos => lvrLidos.Livro.Nome)
                .ThenByDescending(lvrLidos => lvrLidos.Avaliacao)
                .Include(l => l.Livro)
                .Include(l => l.User)
                .ToListAsync();
        }

        public async Task<int> Save(LivrosLidos livrosLidos)
        {
            _context.Add(livrosLidos);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(LivrosLidos livrosLidos)
        {
            _context.Update(livrosLidos);
            return await _context.SaveChangesAsync();
        }
    }
}
