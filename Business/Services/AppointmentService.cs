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
        private readonly IPatientRepository _patientRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        
        public AppointmentService(IMapper Mapper, IConfiguration configuration, IAppointmentRepository appointmentRepository, IPatientRepository patientRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
        }

        public async Task<RequestResult<RequestAnswer>> CreateAppointment(AppointmentDto appointmentDto)
        {
            try
            {
                var model = _Mapper.Map<Appointment>(appointmentDto);
                model.Status = StatusEnum.Created;

                //Check if the patient, schedule, employee and student exists
                if(appointmentDto.IdPatient > 0) {
                    var responsePatient  = await _patientRepository.GetPatientById(appointmentDto.IdPatient);
                    if(responsePatient == null) { 
                        return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentCreateError, true);
                    }
                    model.Patient = responsePatient;
                }

                if(appointmentDto.IdSchedule > 0) {
                    var responseSchedule  = await _scheduleRepository.GetScheduleById(appointmentDto.IdSchedule);
                    if(responseSchedule == null)
                        return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentCreateError, true);
                    model.Schedule = responseSchedule;
                }

                if(appointmentDto.IdStudent > 0) {
                    var responseStudent  = await _studentRepository.GetStudentById(appointmentDto.IdStudent);
                    if(responseStudent == null)
                        return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentCreateError,true);
                    model.Student = responseStudent;
                }

                if(appointmentDto.IdEmployee > 0) {
                    var responseEmployee  = await _employeeRepository.GetEmployeeById(appointmentDto.IdEmployee);
                    if(responseEmployee == null)
                        return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentCreateError, true);
                    model.Employee = responseEmployee;
                }

                var response = await _appointmentRepository.CreateAppointment(model);
                if (response.Id == 0)
                    return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentCreateError, true);

                return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentCreateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentCreateError, true);
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

        public async Task<RequestResult<RequestAnswer>> UpdateAppointment(AppointmentDto appointment, int id) 
        {
            try
            {
                var appointmentDatabase = await _appointmentRepository.GetAppointmentById(id); 

                if(appointmentDatabase != null) {
                    if(Rules.Check48HoursBefore(appointmentDatabase.DateAndTime, DateTime.Now)){
                        var model = _Mapper.Map<Appointment>(appointment);
                        await _appointmentRepository.UpdateAppointment(model);

                        return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentUpdateSuccess);
                    }else{
                        return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentLessThan48Hours, true);
                    }
                }else{
                    return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentNotFound, true);
                }
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
                var appointment = await _appointmentRepository.GetAppointmentById(id); 
                
                if(Rules.Check48HoursBefore(appointment.DateAndTime, DateTime.Now)){ 
                    await _appointmentRepository.DeleteAppointment(id);
                    return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentDeleteSuccess);
                }else{
                    return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentLessThan48Hours, true); 
                }          
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.AppointmentDeleteError, true);
            }
        }

        public async Task<RequestResult<AppointmentDto[]>> GetAppointments() {
            try {
                var result = await _appointmentRepository.GetAppointments();
                var dto = _Mapper.Map<AppointmentDto[]>(result);
                return new RequestResult<AppointmentDto[]>(dto);
            } catch(Exception) {
                return new RequestResult<AppointmentDto[]>(null, true, RequestAnswer.AppointmentNotFound.GetDescription());
            }
        }
    }
}
