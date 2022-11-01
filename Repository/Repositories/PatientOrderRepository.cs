using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using System;

namespace Repository.Repositories
{
    public class PatientOrderRepository : IPatientOrderRepository
    {
        private readonly TemplateDbContext _context;
        public PatientOrderRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<PatientOrder> CreatePatientOrder(PatientOrder patient_order)
        {
            var result = await _context.PatientOrders.AddAsync(patient_order);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdatePatientOrder(PatientOrder patient_order)
        {
            _context.PatientOrders.Update(patient_order);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePatientOrder(int id)
        {
            var patient_order = await _context.PatientOrders.Where(u => u.id == id).FirstOrDefaultAsync();
            patient_order.active = false;

            _context.PatientOrders.Update(patient_order);
            await _context.SaveChangesAsync();
        }

        public async Task<PatientOrder> GetPatientOrderById(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
