using Contracts.Enums.Status;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities {
    [Table("appointment")]
    public partial class Appointment
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("date")]
        public DateTime DateAndTime { get; set; }

        [Column("status")]
        [Required]
        public StatusEnum Status { get; set; }

        [Column("cancellation_reason")]
        public string CancellationReason { get; set; }

        [Column("id_schedule")]
        public Schedule Schedule { get; set; }

        [Column("id_patient")]
        public Patient Patient { get; set; }

        [Column("id_employee")]
        public Employee Employee { get; set; }

        [Column("id_student")]
        public Student Student { get; set; }

        [Column("new_patient")]
        public bool NewPatient { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("duration")]
        public string Duration { get; set; }

        [Column("companion")]
        public bool Companion { get; set; }

        [Column("location")]
        public string Location { get; set; }
    }
}
