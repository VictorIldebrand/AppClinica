using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly TemplateDbContext _context;

        public StudentRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            var result = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _context.Students.Where(u => u.Id == id).FirstOrDefaultAsync();
            student.Active = false;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.Where(u => u.Id == id && u.Active).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIfStudentExistsById(int id)
        {
            var result = await _context.Students.AnyAsync(u => u.Id == id && u.Active);
            return result;
        }

        public async Task<bool> CheckIfStudentExistsByEmail(string email)
        {
            var result = await _context.Students.AnyAsync(u => u.Email == email && u.Active);
            return result;
        }

        public async Task<bool> CheckIfStudentExistsByRa(string ra)
        {
            var result = await _context.Students.AnyAsync(u => u.Ra == ra && u.Active);
            return result;
        }

        public async Task<string> GetStudentPasswordByEmail(string email)
        {
            var result = await _context.Students.Where(u => u.Email == email && u.Active).Select(p => p.Password).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Student> GetStudentByEmailAndPassword(string email, string password)
        {
            return await _context.Students.Where(x => x.Email == email && x.Password == password && x.Active).FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            var result = await _context.Students.Where(u => u.Email == email && u.Active).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Student> GetStudentByRa(string ra)
        {
            var result = await _context.Students.Where(u => u.Ra == ra && u.Active).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Student[]> GetAllStudents()
        {
            return await _context.Students.Where(u => u.Active).ToArrayAsync();
        }
    }
}
