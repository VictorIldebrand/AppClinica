using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using System;

namespace Repository.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TemplateDbContext _context;

        public NotificationRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<Notification> CreateNotification(Notification notification)
        {
            var result = await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdateNotification(Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotification(int id)
        {
            var notification = await _context.Notifications.Where(u => u.id == id).FirstOrDefaultAsync();
            notification.status = 0;

            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<Notification> GetNotificationByPatientId(int idPatient) {
            return await _context.Notifications.Where(u => u.id == idPatient).FirstOrDefaultAsync();
        }

        public async Task<Notification> GetNotificationByStudentId(int idStudent) {
            return await _context.Notifications.Where(u => u.id == idStudent).FirstOrDefaultAsync();
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> CheckIfNotificationExistsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
