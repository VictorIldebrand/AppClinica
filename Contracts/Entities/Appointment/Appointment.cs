using Contracts.Entities.Attributes;
using Contracts.Enums.Status;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("appointment")]
    public partial class Appointment
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("status")]
        [Required]
        public StatusEnum Status { get; set; }

        [Column("cancellation_reason")]
        public string CancellationReason { get; set; }

        [Column("id_schedule")]
        public int IdSchedule { get; set; }

        [Column("id_patient")]
        public int IdPatient { get; set; }

        [Column("id_employee")]
        public int IdEmployee { get; set; }

        [Column("new_patient")]
        public bool NewPatient { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("note")]
        public string Note { get; set; }
    }
}
