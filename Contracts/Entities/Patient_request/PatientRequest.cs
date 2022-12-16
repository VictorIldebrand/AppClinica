using Contracts.Enums.Status;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities {
    [Table("patient_request")]
    public partial class PatientRequest
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("date_solicitation")]
        public DateTime DateSolicitation { get; set; }

        [Column("date_treatment")]
        public DateTime DateTreatment { get; set; }

        [Column("status")]
        [Required]
        public bool Status { get; set; }

        [Column("id_student")]
        [Required]
        public int StudentId;

        [Required]
        public Student Student { get; set; }

        [Column("new_patient")]
        public bool NewPatient { get; set; }

        [Column("procedure")]
        public string Procedure { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}
