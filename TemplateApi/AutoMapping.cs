using AutoMapper;
using Contracts.Dto.Appointment;
using Contracts.Dto.Employee;
using Contracts.Dto.Notification;
using Contracts.Dto.Patient;
//using Contracts.Dto.PatientOrder;
using Contracts.Dto.PatientRequest;
using Contracts.Dto.Professor;
using Contracts.Dto.Schedule;
using Contracts.Dto.ScheduleProfessor;
using Contracts.Dto.Student;
using Contracts.DTO.User;
using Contracts.Entities;
using Contracts.TransactionObjects.User;

namespace TemplateApi
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            UserMap();
            EmployeeMap();
            AppointmentMap();
            NotificationMap();
            // PatientOrderMp();
            PatientMap();
            PatientRequestMap();
            ProfessorMap();
            ScheduleProfessorMap();
            ScheduleMap();
            StudentMap();
        }

        private void UserMap()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserDto>().ReverseMap();
        }

        private void AppointmentMap()
        {
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, AppointmentMinDto>();
            CreateMap<Appointment, AppointmentMinDto>().ReverseMap();
        }

        private void EmployeeMap()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeMinDto>();
            CreateMap<Employee, EmployeeMinDto>().ReverseMap();
            CreateMap<Employee[], FilterInfoDto[]>();
            CreateMap<Employee[], FilterInfoDto[]>().ReverseMap();
        }

        private void NotificationMap()
        {
            CreateMap<Notification, NotificationDto>();
            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<Notification, NotificationMinDto>();
            CreateMap<Notification, NotificationMinDto>().ReverseMap();
        }

        // private void PatientOrderMap()
        // {
        //     CreateMap<PatientOrder, PatientOrderDto>();
        //     CreateMap<PatientOrder, PatientOrderDto>().ReverseMap();
        //     CreateMap<PatientOrder, PatientOrderMinDto>();
        //     CreateMap<PatientOrder, PatientOrderMinDto>().ReverseMap();
        // }

        private void PatientMap()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Patient, PatientMinDto>();
            CreateMap<Patient, PatientMinDto>().ReverseMap();
            CreateMap<Patient[], FilterInfoDto[]>();
            CreateMap<Patient[], FilterInfoDto[]>().ReverseMap();
        }

        private void PatientRequestMap()
        {
            CreateMap<PatientRequest, PatientRequestDto>();
            CreateMap<PatientRequest, PatientRequestDto>().ReverseMap();
            CreateMap<PatientRequest, PatientRequestMinDto>();
            CreateMap<PatientRequest, PatientRequestMinDto>().ReverseMap();
        }

        private void ProfessorMap()
        {
            CreateMap<Professor, ProfessorDto>();
            CreateMap<Professor, ProfessorDto>().ReverseMap();
            CreateMap<Professor, ProfessorMinDto>();
            CreateMap<Professor, ProfessorMinDto>().ReverseMap();
            CreateMap<Professor[], FilterInfoDto[]>();
            CreateMap<Professor[], FilterInfoDto[]>().ReverseMap();
        }

        private void ScheduleProfessorMap()
        {
            CreateMap<ScheduleProfessor, ScheduleProfessorDto>();
            CreateMap<ScheduleProfessor, ScheduleProfessorDto>().ReverseMap();
            CreateMap<ScheduleProfessor, ScheduleProfessorMinDto>();
            CreateMap<ScheduleProfessor, ScheduleProfessorMinDto>().ReverseMap();
        }

        private void ScheduleMap()
        {
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<Schedule, ScheduleDto>().ReverseMap();
            CreateMap<Schedule, ScheduleMinDto>();
            CreateMap<Schedule, ScheduleMinDto>().ReverseMap();
        }

        private void StudentMap()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentMinDto>();
            CreateMap<Student, StudentMinDto>().ReverseMap();
            CreateMap<Student[], FilterInfoDto[]>();
            CreateMap<Student[], FilterInfoDto[]>().ReverseMap();
        }
    }
}
