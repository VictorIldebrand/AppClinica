using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly TemplateDbContext _context;
        public ProfessorRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<Professor> CreateProfessor(Professor professor)
        {
            var result = await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdateProfessor(Professor professor)
        {
            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProfessor(int id)
        {
            var professor = await _context.Professors.Where(u => u.id == id).FirstOrDefaultAsync();
            professor.active = false;

            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();
        }
    }
}
