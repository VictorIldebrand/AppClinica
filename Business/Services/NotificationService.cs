using AutoMapper;
using Contracts.Dto.Notification;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
namespace Business.Services {
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

        public async Task<RequestResult<RequestAnswer>> CreateNotification(NotificationDto notificationDto)
        {
            try
            {
                var model = _Mapper.Map<Notification>(notificationDto);
                model.Read = false;
                var response = await _notificationRepository.CreateNotification(model);
                if (response.Id == 0)
                    return new RequestResult<RequestAnswer>(RequestAnswer.NotificationCreateError, true);
                
                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationCreateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationCreateError, true);
            }
        }

        public async Task<RequestResult<NotificationDto>> GetNotificationById(int id)
        {
            try
            {
                var model = await _notificationRepository.GetNotificationById(id);

                if (model == null)
                    return new RequestResult<NotificationDto>(null, true, RequestAnswer.NotificationNotFound.GetDescription());

                var dto = _Mapper.Map<NotificationDto>(model);
                var result = new RequestResult<NotificationDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<NotificationDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<NotificationDto[]>> GetAllNotification()
        {
            try
            {
                Notification[] model = await _notificationRepository.GetAllNotification();

                if (model == null)
                    return new RequestResult<NotificationDto[]>(new NotificationDto[1]);

                var dto = _Mapper.Map<NotificationDto[]>(model);
                var result = new RequestResult<NotificationDto[]>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<NotificationDto[]>(null, true, ex.Message);
            }
        }


        public async Task<RequestResult<RequestAnswer>> UpdateNotification(NotificationDto notificationDto, int id) {
            try
            {
                var notificationCheck = await _notificationRepository.CheckIfNotificationExistsById(id);

                if (!notificationCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.NotificationNotFound, true);

                var model = _Mapper.Map<Notification>(notificationDto);
                await _notificationRepository.UpdateNotification(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationUpdateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationUpdateError, true);
            }
        }

        public async Task<RequestResult<RequestAnswer>> DeleteNotification(int id)
        {
            try
            {
                await _notificationRepository.DeleteNotification(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationDeleteSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationDeleteError, true);
            }
        }
    }
}
