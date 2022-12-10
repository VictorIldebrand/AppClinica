using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities {
    [Table("schedule_professor")]
    public partial class ScheduleProfessor
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("id_schedule")]
        [Required]
        public int ScheduleId;

        [Required]
        public Schedule Schedule { get; set; }

        [Column("id_professor")]
        [Required]
        public int ProfessorId;

        [Required]
        public Professor Professor { get; set; }

        public PatientRequest PatientRequest { get; set; }

    }
}
