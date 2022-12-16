
using Contracts.Dto.Professor;
using Contracts.Dto.Schedule;

namespace Contracts.Dto.ScheduleProfessor
{
    public class ScheduleProfessorMinDto
    {
        public int Id { get; set; }
        public ScheduleDto Schedule { get; set; }
        public ProfessorDto Professor { get; set; }
    }
}
