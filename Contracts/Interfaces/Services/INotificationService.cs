using Contracts.DTO.Notification;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface INotificationService {
        Task<RequestResult<LoginResponseDto>> CreateNotification(NotificationDTO notificationDTO);
        Task<RequestResult<NotificationDTO>> GetNotificationById(int id);
        Task<RequestResult<RequestAnswer>> DeleteNotification(int id);
    }
}
