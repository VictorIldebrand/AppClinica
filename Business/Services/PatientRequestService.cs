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

        public PatientRequestService(IMapper Mapper, IConfiguration configuration, IPatientRequestRepository patientRequestRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _patientRequestRepository = patientRequestRepository;
        }

        public async Task<RequestResult<PatientRequestDto>> CreatePatientRequest(PatientRequestDto patientRequestDto)
        {
            try{
                var patientRequestExists = await _patientRequestRepository.CheckIfPatientRequestExistsById(patientRequestDto.Id);
                if (patientRequestExists)
                    return new RequestResult<PatientRequestDto>(null, true, RequestAnswer.PatientRequestDuplicateCreateError.GetDescription());
                var model = _Mapper.Map<PatientRequest>(patientRequestDto);
                model.Status = 0;
                var response = await _patientRequestRepository.CreatePatientRequest(model);
                if (response.Id == 0)
                    return new RequestResult<PatientRequestDto>(null, true, RequestAnswer.PatientRequestCreateError.GetDescription());
                var dto = _Mapper.Map<PatientRequestDto>(response);
                /*var loginDto = new LoginResponseDto
                {
                    Email = response.email,
                    Password = response.password
                };*/
                //var login = await Login(loginDto);
                return new RequestResult<PatientRequestDto>(patientRequestDto);
            }
            catch (Exception ex)
            {
                return new RequestResult<PatientRequestDto>(null, true, ex.Message);
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

        public async Task<RequestResult<RequestAnswer>> UpdatePatientRequest(PatientRequestDto patientRequestDto)
        {
            try
            {
                var patientRequestCheck = await _patientRequestRepository.CheckIfPatientRequestExistsById(patientRequestDto.Id);

                if (!patientRequestCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestNotFound);

                var model = _Mapper.Map<PatientRequest>(patientRequestDto);
                await _patientRequestRepository.UpdatePatientRequest(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.PatientUpdateSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.PatientUpdateError, true);
            }
        }

        public async Task<RequestResult<RequestAnswer>> DeletePatientRequest(int id)
        {
            try
            {
                await _patientRequestRepository.DeletePatientRequest(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestDeleteSuccess);
            }
            catch (Exception)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.PatientRequestDeleteError, true);
            }
        }
    }
}
