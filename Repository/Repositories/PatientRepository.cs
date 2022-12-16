using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using System;

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
            return await _context.Patients.Where(u => u.Id == id && u.Active).FirstOrDefaultAsync();
        }

        public async Task<Patient[]> GetAllPatients()
        {
            return await _context.Patients.Where(u => u.Active).ToArrayAsync();
        }

        public async Task<Patient> GetPatientByEmailAndPassword(string email, string password)
        {
            return await _context.Patients.Where(x => x.Email == email && x.Password == password && x.Active).FirstOrDefaultAsync();
        }
        
        public async Task<bool> CheckIfPatientExistsById(int id)
        {
            return await _context.Patients.AnyAsync(u => u.Id == id && u.Active);
        }

        public async Task<bool> CheckIfPatientExistsByEmail(string email) {
            return await _context.Patients.AnyAsync(u => u.Email == email && u.Active);
        }

        public async Task<bool> CheckIfPatientExistsByCpf(string cpf) {
            return await _context.Patients.AnyAsync(u => u.Cpf == cpf && u.Active);
        }

        public async Task UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeletePatient(int id)
        {
            var patient = await _context.Patients.Where(u => u.Id == id).FirstOrDefaultAsync();
            if(patient == null || !patient.Active){
                throw new Exception("Paciente já removido ou não encontrado");
            }
            patient.Active = false;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public Task<Patient> GetPatientByEmail(string email) {
            throw new NotImplementedException();
        }
    }
}
