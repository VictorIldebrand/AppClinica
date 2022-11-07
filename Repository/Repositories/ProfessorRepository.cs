using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using System;

namespace Repository.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly TemplateDbContext _context;

        public ProfessorRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<Professor> GetProfessorById(int id)
        {
            return await _context.Professors.Where(u => u.id == id && u.active).FirstOrDefaultAsync();
        }

        public async Task<Professor> GetProfessorByEmailAndPassword(string email, string password)
        {
            return await _context.Professors.Where(x => x.email == email && x.password == password && x.active).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIfProfessorExistsByEmail(string email)
        {
            var result = await _context.Professors.AnyAsync(u => u.email == email && u.active);
            return result;
        }

        public async Task<bool> CheckIfProfessorExistsById(int id)
        {
            var result = await _context.Professors.AnyAsync(u => u.email == email && u.active);
            return result;
        }

        public async Task<Professor> GetProfessorByEmail(string email)
        {
            var result = await _context.Professors.Where(u => u.email == email && u.active).FirstOrDefaultAsync();
            return result;
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
