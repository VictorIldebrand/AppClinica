using Contracts.Entities;
using Contracts.Enums.Auth;
using Contracts.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories {
    public class EmployeeRepository : IEmployeeRepository {
        private readonly TemplateDbContext _context;

        public EmployeeRepository(TemplateDbContext context) {
            _context = context;
        }

        public async Task<Employee> Register(Employee employee) {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
        public async Task<bool> CheckIfUserExistsByEmail(string email) {
            var result = await _context.Employees.AnyAsync(u => u.email == email && u.active);
            return result;
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Register(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmployeeByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
