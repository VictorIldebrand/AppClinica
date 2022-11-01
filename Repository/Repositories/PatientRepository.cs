using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly TemplateDbContext _context;
        public PatientRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            var result = await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePatient(int id)
        {
            var patient = await _context.Patients.Where(u => u.id == id).FirstOrDefaultAsync();
            patient.active = false;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
