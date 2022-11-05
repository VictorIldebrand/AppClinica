using Contracts.Dto.Notification;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface INotificationService {
        Task<RequestResult<LoginResponseDto>> CreateNotification(NotificationDto notification);
        Task<RequestResult<NotificationDto>> GetNotificationById(int id);
        Task<RequestResult<NotificationDto>> UpdateNotification(NotificationDto notification);
        Task<RequestResult<RequestAnswer>> DeleteNotification(int id);
    }
}
