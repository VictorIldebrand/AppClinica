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
        public int id { get; set; }

        [Column("date")]
        public DateTime date { get; set; }

        [Column("status")]
        [Required]
        public StatusEnum status { get; set; }

        [Column("cancellation_reason")]
        public string cancellationReason { get; set; }

        [Column("id_schedule")]
        public int idSchedule { get; set; }

        [Column("id_patient")]
        public int idPatient { get; set; }

        [Column("id_employee")]
        public int idEmployee { get; set; }

        [Column("new_patient")]
        public bool newPatient { get; set; }

        [Column("type")]
        public string type { get; set; }

        [Column("note")]
        public string note { get; set; }
    }
}
