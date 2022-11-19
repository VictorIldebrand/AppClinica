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

        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patients.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Patient[]> GetAllPatients()
        {
            return await _context.Patients.Where(u => u.Active).ToArrayAsync();
        }

        public async Task<Patient> GetPatientByEmailAndPassword(string email, string password)
        {
            throw new System.NotImplementedException();
        }
        
        public async Task<bool> CheckIfPatientExistsByEmail(string email)
        {
            var result = await _context.Patients.AnyAsync(u => u.Email == email && u.Active);
            return result;
        }

        public async Task<Patient> GetPatientByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeletePatient(int id)
        {
            var patient = await _context.Patients.Where(u => u.Id == id).FirstOrDefaultAsync();
            patient.Active = false;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
