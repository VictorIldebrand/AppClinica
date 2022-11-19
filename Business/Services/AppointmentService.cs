using AutoMapper;
using Contracts.Dto.Appointment;
using Contracts.Entities;
using Contracts.Enums.Status;
using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
namespace Business.Services {
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IMapper Mapper, IConfiguration configuration, IAppointmentRepository appointmentRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<RequestResult<AppointmentDto>> CreateAppointment(AppointmentDto appointmentDto)
        {
            try
            {
                var model = _Mapper.Map<Appointment>(appointmentDto);
                model.Status = StatusEnum.Confirmed;
                var response = await _appointmentRepository.CreateAppointment(model);
                if (response.Id == 0)
                    return new RequestResult<AppointmentDto>(null, true, RequestAnswer.AppointmentCreateError.GetDescription());
                var dto = _Mapper.Map<AppointmentDto>(response);
                return new RequestResult<AppointmentDto>(dto);
            }
            catch (Exception ex)
            {
                return new RequestResult<AppointmentDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<AppointmentDto>> GetAppointmentByDate(DateTime date)
        {
            try
            {
                var model = await _appointmentRepository.GetAppointmentByDate(date);

                if(model == null)
                    return new RequestResult<AppointmentDto>(null, true, RequestAnswer.AppointmentNotFound.GetDescription());

                var dto = _Mapper.Map<AppointmentDto>(model);
                var result = new RequestResult<AppointmentDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<AppointmentDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> UpdateAppointment(AppointmentDto appointment)
        {
            try
            {
                var appointmentCheck = await _appointmentRepository.CheckIfAppointmentExistsById(appointment.Id);

                if(!appointmentCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentNotFound);

                var model = _Mapper.Map<Appointment>(appointment);
                await _appointmentRepository.UpdateAppointment(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentUpdateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentUpdateError, true);
            }
        }

        public async Task<RequestResult<RequestAnswer>> DeleteAppointment(int id)
        {
            try
            {
                await _appointmentRepository.DeleteAppointment(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentDeleteSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentDeleteError, true);
            }
        }

        public Task<RequestResult<AppointmentDto>> GetAppointments() {
            throw new NotImplementedException();
        }
    }
}
