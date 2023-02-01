using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Security.Principal;
using WishListBooks.Models;
using WishListBooks.Models.Entities;

namespace WishListBooks.Repository
{
    public class UserRepository
    {
        private readonly ContextoDatabase _context;

        public UserRepository(ContextoDatabase context)
        {
            _context = context;
        }

        public async Task<int> Delete(int id)
        {
            var user = await _context.FindAsync<User>(id);
            _context.Remove(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> FindUserByLogin(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> Save(User user)
        {
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(user).Property(p => p.CreatedDate).IsModified = false;
            _context.Update(user);
            return await _context.SaveChangesAsync();
        }
    }
}
