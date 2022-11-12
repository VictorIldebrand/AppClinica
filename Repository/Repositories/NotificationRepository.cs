﻿using System.Linq;
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
            var notification = await _context.Notifications.Where(u => u.Id == id).FirstOrDefaultAsync();

            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<Notification> GetNotificationByPatientId(int idPatient) {
            return await _context.Notifications.Where(u => u.IdPatient == idPatient).FirstOrDefaultAsync();
        }

        public async Task<Notification> GetNotificationByStudentId(int idStudent) {
            return await _context.Notifications.Where(u => u.IdStudent == idStudent).FirstOrDefaultAsync();
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            return await _context.Notifications.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Notification[]> GetAllNotification() {
            return await _context.Notifications.Where(u => !u.Read).ToArrayAsync(); //0->Notifications NOT read yet 
        }

        public async Task<bool> CheckIfNotificationExistsById(int id)
        {
            var result = await _context.Notifications.AnyAsync(u => u.Id == id);
            return result;
        }
    }
}
