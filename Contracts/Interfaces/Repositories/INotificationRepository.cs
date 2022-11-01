using Contracts.Entities;
using System.Threading.Tasks;
namespace Contracts.Interfaces.Repositories {
    public interface INotificationRepository {
        Task<Notification> GetNotificationByPatientId(int idPatient);
        Task<Notification> GetNotificationByStudentId(int idStudent);
        Task DeleteNotification(int id);
        Task UpdateNotification(Notification notification);
        Task<Notification> CreateNotification(Notification notification);
    }
}
