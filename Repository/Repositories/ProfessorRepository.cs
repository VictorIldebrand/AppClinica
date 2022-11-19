using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class ProfessorRepository : IProfessorRepository {
        private readonly TemplateDbContext _context;

        public ProfessorRepository(TemplateDbContext context) {
            _context = context;
        }

        public async Task<Professor> GetProfessorById(int id) {
            return await _context.Professors.Where(u => u.Id == id && u.Active).FirstOrDefaultAsync();
        }



        public async Task<Professor> GetProfessorByEmailAndPassword(string email, string password) {
            return await _context.Professors.Where(x => x.Email == email && x.Password == password && x.Active).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIfProfessorExistsByEmail(string email) {
            var result = await _context.Professors.AnyAsync(u => u.Email == email && u.Active);
            return result;
        }

        public async Task<bool> CheckIfProfessorExistsById(int id) {
            var result = await _context.Professors.AnyAsync(u => u.Id == id && u.Active);
            return result;
        }

        public async Task<Professor> GetProfessorByEmail(string email) {
            var result = await _context.Professors.Where(u => u.Email == email && u.Active).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Professor> CreateProfessor(Professor professor) {
            var result = await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdateProfessor(Professor professor) {
            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfessor(int id) {
            var professor = await _context.Professors.Where(u => u.Id == id).FirstOrDefaultAsync();
            professor.Active = false;

            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();
        }

        public async Task<Professor[]> GetAllProfessors()
        {
            Professor[] professors = await _context.Professors.Where(x => x.Active).ToArrayAsync();
            return professors;
        }
    }
}
