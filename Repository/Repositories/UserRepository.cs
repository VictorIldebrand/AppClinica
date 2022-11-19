using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories {
    public class UserRepository : IUserRepository
    {
        private readonly TemplateDbContext _context;

        public UserRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Where(u => u.Id == id && u.Active).FirstOrDefaultAsync();
        }

        public async Task<User> Register(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await _context.Users.Where(x => x.Email == email && x.Password == password && x.Active).FirstOrDefaultAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            user.Active = false;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _context.Users.Where(u => u.Email == email && u.Active).FirstOrDefaultAsync();
            return result;
        }

        public async Task<string> GetUserPasswordByUserEmail(string email)
        {
            var result = await _context.Users.Where(u => u.Email == email && u.Active).Select(p => p.Password).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> CheckIfUserExistsById(int id)
        {
            var result = await _context.Users.AnyAsync(u => u.Id == id && u.Active);
            return result;
        }

        public async Task<bool> CheckIfUserExistsByEmail(string email)
        {
            var result = await _context.Users.AnyAsync(u => u.Email == email && u.Active);
            return result;
        }

    }
}
