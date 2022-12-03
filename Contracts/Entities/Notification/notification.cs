using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities {
    [Table("notification")]
    public partial class Notification
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("id_appointment")]
        public Appointment Appointment { get; set; }

        [Column("id_patient_request")]
        public PatientRequest PatientRequest { get; set; }

        [Column("read")]
        [Required]
        public bool Read { get; set; }

        [Column("message")]
        [Required]
        public string Message { get; set; }
    }
}
