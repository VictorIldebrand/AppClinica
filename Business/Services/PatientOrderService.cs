// using AutoMapper;
// using Contracts.Dto.Patient;
// using Contracts.Dto.PatientOrder;
// using Contracts.DTO.User;
// using Contracts.Entities;
// using Contracts.Interfaces.Repositories;
// using Contracts.Interfaces.Services;
// using Contracts.RequestHandle;
// using Contracts.TransactionObjects.Login;
// using Contracts.Utils;
// using Microsoft.Extensions.Configuration;
// using System;
// using System.Threading.Tasks;
// namespace Business.Services
// {
//     public class PatientOrderService : IPatientOrderService
//     {
//         private readonly IMapper _Mapper;
//         private readonly IConfiguration _configuration;
//         private readonly IPatientOrderRepository _patientOrderRepository;

//         public PatientOrderService(IMapper Mapper, IConfiguration configuration, IPatientOrderRepository patientOrderRepository)
//         {
//             _Mapper = Mapper;
//             _configuration = configuration;
//             _patientOrderRepository = patientOrderRepository;
//         }

//         public async Task<RequestResult<PatientOrderDto>> CreatePatientOrder(PatientOrderDto registerRequest)
//         {
//             try
//             {
//                 var model = _Mapper.Map<PatientOrder>(registerRequest);
//                 model.active = true;
//                 var response = await _patientOrderRepository.CreatePatientOrder(model);
//                 if (response.id == 0)
//                     return new RequestResult<PatientOrderDto>(null, true, RequestAnswer.PatientOrderCreateError.GetDescription());
//                 var dto = _Mapper.Map<PatientOrderDto>(response);
//                 return new RequestResult<PatientOrderDto>(registerRequest);
//             }
//             catch (Exception ex)
//             {
//                 return new RequestResult<PatientOrderDto>(null, true, ex.Message);
//             }
//         }

//         public async Task<RequestResult<PatientOrderDto>> GetPatientOrderById(int id) {
//             try
//             {
//                 var model = await _patientOrderRepository.GetPatientOrderById(id);

//                 if (model == null)
//                     return new RequestResult<PatientOrderDto>(null, true, RequestAnswer.PatientOrderNotFound.GetDescription());

//                 var dto = _Mapper.Map<PatientOrderDto>(model);
//                 var result = new RequestResult<PatientOrderDto>(dto);

//                 return result;
//             }
//             catch (Exception ex)
//             {
//                 return new RequestResult<PatientOrderDto>(null, true, ex.Message);
//             }
//         }

//         public async Task<RequestResult<RequestAnswer>> UpdatePatientOrder(PatientOrderDto patientOrder)
//         {
//             try
//             {
//                 var model = _Mapper.Map<PatientOrder>(patientOrder);
//                 await _patientOrderRepository.UpdatePatientOrder(model);

//                 return new RequestResult<RequestAnswer>(RequestAnswer.PatientOrderUpdateSuccess);
//             }
//             catch (Exception)
//             {
//                 return new RequestResult<RequestAnswer>(RequestAnswer.PatientOrderUpdateError, true);
//             }
//         }

//         public async Task<RequestResult<RequestAnswer>> DeletePatientOrder(int id)
//         {
//            try
//             {
//                 await _patientOrderRepository.DeletePatientOrder(id);

//                 return new RequestResult<RequestAnswer>(RequestAnswer.PatientOrderDeleteSuccess);
//             }
//             catch (Exception)
//             {
//                 return new RequestResult<RequestAnswer>(RequestAnswer.PatientOrderDeleteError, true);
//             }
//         }
//     }
// }
