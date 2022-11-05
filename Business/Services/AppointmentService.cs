using AutoMapper;
using Contracts.Dto.Appointment;
using Contracts.Dto.Employee;
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

        public async Task<RequestResult<AppointmentDto>> CreateAppointment(AppointmentDto registerRequest)
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

        public async Task<RequestResult<AppointmentDto>> GetAppointmentByDate(DateTime date)
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

        public async Task<RequestResult<RequestAnswer>> UpdateAppointment(AppointmentDto appointment)
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

        public async Task<RequestResult<RequestAnswer>> DeleteAppointment(int id)
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
