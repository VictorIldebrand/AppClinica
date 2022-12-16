using AutoMapper;
using Contracts.Dto.Notification;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services {
    public class NotificationService : INotificationService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly INotificationRepository _notificationRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRequestRepository _patientRequestRepository;

        public NotificationService(IMapper Mapper, IConfiguration configuration, INotificationRepository notificationRepository, IAppointmentRepository appointmentRepository, IPatientRequestRepository patientRequestRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _notificationRepository = notificationRepository;
            _appointmentRepository = appointmentRepository;
            _patientRequestRepository = patientRequestRepository;
        }

        public async Task<RequestResult<RequestAnswer>> CreateNotification(NotificationDto notificationDto)
        {
            try
            {
                var model = _Mapper.Map<Notification>(notificationDto);
                model.Read = false;

                if (notificationDto.IdAppointment > 0 && notificationDto.IdPatientRequest <= 0)
                {
                    var responseAppointment = await _appointmentRepository.GetAppointmentById(notificationDto.IdAppointment);
                    if (responseAppointment == null)
                    {
                        return new RequestResult<RequestAnswer>(RequestAnswer.NotificationCreateError, true);
                    }
                    model.Appointment = responseAppointment;
                    model.AppointmentId = responseAppointment.Id;
                    //model.PatientRequest = null;
                    //model.PatientRequestId = 1;
                } else if (notificationDto.IdPatientRequest > 0 && notificationDto.IdAppointment <= 0)
                {
                    var responsePatientRequest = await _patientRequestRepository.GetPatientRequestById(notificationDto.IdPatientRequest);
                    if (responsePatientRequest == null)
                    {
                        return new RequestResult<RequestAnswer>(RequestAnswer.NotificationCreateError, true);
                    }
                    model.PatientRequest = responsePatientRequest;
                    model.PatientRequestId = responsePatientRequest.Id;
                    //model.Appointment = null;
                    //model.AppointmentId = 1;
                }
                else
                {
                    return new RequestResult<RequestAnswer>(RequestAnswer.NotificationCreateError, true);
                }

                
                var response = await _notificationRepository.CreateNotification(model);
                if (response.Id == 0)
                    return new RequestResult<RequestAnswer>(RequestAnswer.NotificationCreateError, true);
                
                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationCreateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationCreateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<NotificationMinDto>> GetNotificationById(int id)
        {
            try
            {
                var model = await _notificationRepository.GetNotificationById(id);

                if (model == null)
                    return new RequestResult<NotificationMinDto>(null, true, RequestAnswer.NotificationNotFound.GetDescription());

                var dto = _Mapper.Map<NotificationMinDto>(model);
                var result = new RequestResult<NotificationMinDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<NotificationMinDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<IEnumerable<NotificationMinDto>>> GetAllNotification()
        {
            try
            {
                var model = await _notificationRepository.GetAllNotification();

                if (model == null)
                    return new RequestResult<IEnumerable<NotificationMinDto>>(new NotificationMinDto[1]);

                var dto = _Mapper.Map<IEnumerable<NotificationMinDto>>(model);
                var result = new RequestResult<IEnumerable<NotificationMinDto>>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<IEnumerable<NotificationMinDto>>(null, true, ex.Message);
            }
        }


        public async Task<RequestResult<RequestAnswer>> UpdateNotification(NotificationDto notificationDto) {
            try
            {
                var notificationCheck = await _notificationRepository.CheckIfNotificationExistsById(notificationDto.Id);

                if (!notificationCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.NotificationNotFound, true);

                var model = _Mapper.Map<Notification>(notificationDto);
                model.PatientRequestId = notificationDto.IdPatientRequest;
                model.AppointmentId = notificationDto.IdAppointment;
                await _notificationRepository.UpdateNotification(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationUpdateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationUpdateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> DeleteNotification(int id)
        {
            try
            {
                await _notificationRepository.DeleteNotification(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationDeleteSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.NotificationDeleteError, true, ex.Message);
            }
        }
    }
}
