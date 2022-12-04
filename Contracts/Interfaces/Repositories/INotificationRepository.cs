using Contracts.Entities;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface INotificationRepository {
        Task<Notification> GetNotificationByPatientRequestId(int idPatient);
        Task<Notification> GetNotificationByAppointmentId(int idStudent);
        Task<Notification> GetNotificationById(int id);
        Task<Notification[]> GetAllNotification();
        Task<bool> CheckIfNotificationExistsById(int id);
        Task DeleteNotification(int id);
        Task UpdateNotification(Notification notification);
        Task<Notification> CreateNotification(Notification notification);
    }
}
