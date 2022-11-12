﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using System;

namespace Repository.Repositories
{
    public class ScheduleProfessorRepository : IScheduleProfessorRepository
    {
        private readonly TemplateDbContext _context;

        public ScheduleProfessorRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<ScheduleProfessor> GetScheduleProfessorById(int id)
        {
            return await _context.ScheduleProfessors.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ScheduleProfessor> GetScheduleProfessorByProfessorId(int idProfessor)
        {
            return await _context.ScheduleProfessors.Where(u => u.IdProfessor == idProfessor).FirstOrDefaultAsync();
        }

        public async Task<ScheduleProfessor> GetScheduleProfessorByScheduleId(int idSchedule)
        {
            return await _context.ScheduleProfessors.Where(u => u.IdSchedule == idSchedule).FirstOrDefaultAsync();
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
            var schedule_professor = await _context.ScheduleProfessors.Where(u => u.Id == id).FirstOrDefaultAsync();
            //schedule_professor.Active = false;

            _context.ScheduleProfessors.Update(schedule_professor);
            await _context.SaveChangesAsync();
        }
    }
}
