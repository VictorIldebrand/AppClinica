using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class ScheduleProfessorRepository : IScheduleProfessorRepository
    {
        private readonly TemplateDbContext _context;
        public ScheduleProfessorRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<ScheduleProfessor> CreateScheduleProfessor(ScheduleProfessor schedule_professor)
        {
            var result = await _context.ScheduleProfessors.AddAsync(schedule_professor);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdateScheduleProfessor(ScheduleProfessor schedule_professor)
        {
            _context.ScheduleProfessors.Update(schedule_professor);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteScheduleProfessor(int id)
        {
            var schedule_professor = await _context.ScheduleProfessors.Where(u => u.id == id).FirstOrDefaultAsync();
            //schedule_professor.Active = false;

            _context.ScheduleProfessors.Update(schedule_professor);
            await _context.SaveChangesAsync();
        }
    }
}
