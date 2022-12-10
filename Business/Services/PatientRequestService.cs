using AutoMapper;
using Contracts.Dto.PatientRequest;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using Contracts.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
namespace Business.Services {
    public class PatientRequestService : IPatientRequestService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IPatientRequestRepository _patientRequestRepository;
        private readonly IScheduleProfessorRepository _scheduleProfessorRepository;
        private readonly IStudentRepository _studentRepository;

        public PatientRequestService(IMapper Mapper, IConfiguration configuration, IPatientRequestRepository patientRequestRepository, IScheduleProfessorRepository scheduleProfessorRepository, IStudentRepository studentRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _patientRequestRepository = patientRequestRepository;
            _scheduleProfessorRepository = scheduleProfessorRepository;
            _studentRepository = studentRepository;
        }

        public async Task<RequestResult<RequestAnswer>> CreatePatientRequest(PatientRequestDto patientRequestDto)
        {
            try{
                

                if (Rules.Check48HoursBefore(patientRequestDto.DataSolicitation, patientRequestDto.DataTreatment)) {
                    var student = await _studentRepository.GetStudentById(patientRequestDto.StudentId);
                    if (student == null)
                    {
                        return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestCreateError, true);
                    }
                    var model = _Mapper.Map<PatientRequest>(patientRequestDto);
                    model.Student = student;
                    model.Active = true;
                    var response = await _patientRequestRepository.CreatePatientRequest(model);
                    if (response.Id == 0)
                        return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestCreateError, true);

                    return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestCreateSuccess);
                } else
                    return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequest48HoursBefore, true);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestCreateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<PatientRequestDto>> GetPatientRequestById(int id)
        {
            try
            {
                var model = await _patientRequestRepository.GetPatientRequestById(id);

                if (model == null)
                    return new RequestResult<PatientRequestDto>(null, true, RequestAnswer.PatientRequestNotFound.GetDescription());

                var dto = _Mapper.Map<PatientRequestDto>(model);
                var result = new RequestResult<PatientRequestDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<PatientRequestDto>(null, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> UpdatePatientRequest(PatientRequestDto patientRequestDto, int id)
        {
            try
            {
                var patientRequestCheck = await _patientRequestRepository.CheckIfPatientRequestExistsById(id);

                if (!patientRequestCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestNotFound);

                var model = _Mapper.Map<PatientRequest>(patientRequestDto);
                await _patientRequestRepository.UpdatePatientRequest(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.PatientUpdateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.PatientUpdateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> DeletePatientRequest(int id)
        {
            try
            {
                await _patientRequestRepository.DeletePatientRequest(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestDeleteSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestDeleteError, true, ex.Message);
            }
        }
    }
}
