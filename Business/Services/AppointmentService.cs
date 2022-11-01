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

        public Task<RequestResult<AppointmentDto>> CreateAppointment(AppointmentDto registerRequest)
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
        public Task<RequestResult<AppointmentDto>> GetAppointmentByDate(DateTime date)
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

        public Task<RequestResult<RequestAnswer>> UpdateAppointment(AppointmentDto appointment)
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
        public Task<RequestResult<RequestAnswer>> DeleteAppointment(int id)
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
