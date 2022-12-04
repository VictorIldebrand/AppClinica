using Contracts.Dto.Notification;
using Contracts.RequestHandle;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface INotificationService {
        Task<RequestResult<RequestAnswer>> CreateNotification(NotificationDto notification);
        Task<RequestResult<NotificationDto>> GetNotificationById(int id);
        Task<RequestResult<NotificationDto[]>> GetAllNotification();
        Task<RequestResult<RequestAnswer>> UpdateNotification(NotificationDto notification, int id);
        Task<RequestResult<RequestAnswer>> DeleteNotification(int id);
    }
}
