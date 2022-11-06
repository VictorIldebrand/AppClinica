using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using System;

namespace Repository.Repositories
{
    public class PatientRequestRepository : IPatientRequestRepository
    {
        private readonly TemplateDbContext _context;

        public PatientRequestRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<PatientRequest> GetPatientRequestByStudentId(int idStudent)
        {
            throw new NotImplementedException();
        }

        public async Task<PatientRequest> GetPatientRequestById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PatientRequest> CreatePatientRequest(PatientRequest patient_request)
        {
            var result = await _context.PatientRequests.AddAsync(patient_request);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdatePatientRequest(PatientRequest patient_request)
        {
            _context.PatientRequests.Update(patient_request);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientRequest(int id)
        {
            var patient_request = await _context.PatientRequests.Where(u => u.Id == id).FirstOrDefaultAsync();
            patient_request.Active = false;

            _context.PatientRequests.Update(patient_request);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckIfPatientRequestExistsById(int id) {
            var result = await _context.PatientRequests.AnyAsync(u => u.Id == id && u.Active);
            return result;
        }
    }
}
