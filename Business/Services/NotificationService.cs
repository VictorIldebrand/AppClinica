using AutoMapper;
using Contracts.Dto.Notification;
using Contracts.DTO.User;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
namespace Business.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly INotificationRepository _notificationRepository;
        
        public NotificationService(IMapper Mapper, IConfiguration configuration, INotificationRepository notificationRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _notificationRepository = notificationRepository;
        }
        public Task<RequestResult<LoginResponseDto>> CreateNotification(NotificationDto notificationDto)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<RequestResult<NotificationDto>> GetNotificationById(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<RequestResult<NotificationDto>> UpdateNotification(NotificationDto notificationDto) {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<RequestResult<RequestAnswer>> DeleteNotification(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
