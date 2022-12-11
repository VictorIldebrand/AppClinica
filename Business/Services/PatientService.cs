using System;
using Contracts.Interfaces.Services;
using Contracts.RequestHandle;
using System.Threading.Tasks;
using Contracts.Entities;
using Contracts.Dto.Patient;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Contracts.Interfaces.Repositories;
using Contracts.Utils;
using Contracts.TransactionObjects.User;
using System.Text.RegularExpressions;

namespace Business.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _Mapper;
        private readonly IConfiguration _configuration;
        private readonly IPatientRepository _patientRepository;
        private readonly Regex CpfRegex = new Regex("^\\d{11}$");

        public PatientService(IMapper Mapper, IConfiguration configuration, IPatientRepository patientRepository)
        {
            _Mapper = Mapper;
            _configuration = configuration;
            _patientRepository = patientRepository;
        }

        public async Task<RequestResult<RequestAnswer>> CreatePatient(PatientDto patientDto)
        {
            try
            {
                var patientExistsByEmail = await _patientRepository.CheckIfPatientExistsByEmail(patientDto.Email);
                var patientExistsByCpf = await _patientRepository.CheckIfPatientExistsByCpf(patientDto.Cpf);
                if (patientExistsByEmail || patientExistsByCpf)
                    return new RequestResult<RequestAnswer>(RequestAnswer.PatientDuplicateCreateError, true);
                if (!CpfRegex.Match(patientDto.Cpf).Success)
                    return new RequestResult<RequestAnswer>(RequestAnswer.InvalidCpf, true);
                var model = _Mapper.Map<Patient>(patientDto);
                model.Active = true;
                var response = await _patientRepository.CreatePatient(model);
                if (response.Id == 0)
                    return new RequestResult<RequestAnswer>(RequestAnswer.PatientCreateError, true);
                var dto = _Mapper.Map<PatientMinDto>(response);
                return new RequestResult<RequestAnswer>(RequestAnswer.PatientCreateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.PatientCreateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<PatientDto>> GetPatientById(int id)
        {
            try
            {
                var model = await _patientRepository.GetPatientById(id);

                if (model == null)
                    return new RequestResult<PatientDto>(null, true, RequestAnswer.PatientNotFound.GetDescription());

                var dto = _Mapper.Map<PatientDto>(model);
                var result = new RequestResult<PatientDto>(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new RequestResult<PatientDto>(null, true, ex.Message);
            }
        }

        public async Task<FilterInfoDto[]> GetAllPatients()
        {
            Patient[] patients  = await _patientRepository.GetAllPatients();

            var array = _Mapper.Map<FilterInfoDto[]>(patients);

            return array;
        }

        public async Task<RequestResult<RequestAnswer>> UpdatePatient(PatientDto patientDto, int id)
        {
            try
            {
                var patientCheck = await _patientRepository.CheckIfPatientExistsById(id);
                bool patientCheckByEmail = false;
                bool patientCheckByCpf = false;

                if(patientDto.Email != null)
                    patientCheckByEmail = await _patientRepository.CheckIfPatientExistsByEmail(patientDto.Email);
                if(patientDto.Cpf != null) {
                    if (!CpfRegex.Match(patientDto.Cpf).Success)
                        return new RequestResult<RequestAnswer>(RequestAnswer.InvalidCpf, true);
                    patientCheckByCpf = await _patientRepository.CheckIfPatientExistsByCpf(patientDto.Cpf);
                }
                if(patientCheckByEmail || patientCheckByCpf)
                    return new RequestResult<RequestAnswer>(RequestAnswer.PatientDuplicateCreateError, true);
                if(!patientCheck)
                    return new RequestResult<RequestAnswer>(RequestAnswer.PatientNotFound, true);
                
                var model = _Mapper.Map<Patient>(patientDto);
                await _patientRepository.UpdatePatient(model);

                return new RequestResult<RequestAnswer>(RequestAnswer.PatientUpdateSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.PatientUpdateError, true, ex.Message);
            }
        }

        public async Task<RequestResult<RequestAnswer>> DeletePatient(int id)
        {
            try
            {
                await _patientRepository.DeletePatient(id);

                return new RequestResult<RequestAnswer>(RequestAnswer.PatientDeleteSuccess);
            }
            catch (Exception ex)
            {
                return new RequestResult<RequestAnswer>(RequestAnswer.PatientDeleteError, true, ex.Message);
            }
        }

    }
}
