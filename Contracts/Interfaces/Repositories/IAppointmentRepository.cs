using Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IAppointmentRepository {
        Task<Appointment> GetAppointmentById(int id);
        Task<List<Appointment>> GetAppointmentsByParameters(string especialidade, int professorId, int alunoId, int pacienteId, Enum status, DateTime data);
    }
}
