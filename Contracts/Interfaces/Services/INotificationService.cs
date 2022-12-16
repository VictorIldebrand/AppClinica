using Contracts.Dto.Notification;
using Contracts.RequestHandle;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface INotificationService {
        Task<RequestResult<RequestAnswer>> CreateNotification(NotificationDto notification);
        Task<RequestResult<NotificationMinDto>> GetNotificationById(int id);
        Task<RequestResult<IEnumerable<NotificationMinDto>>> GetAllNotification();
        Task<RequestResult<RequestAnswer>> UpdateNotification(NotificationDto notification);
        Task<RequestResult<RequestAnswer>> DeleteNotification(int id);
    }
}
