using Contracts.Entities.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("student")]
    public partial class Student
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        [SensitiveData]
        public string Name { get; set; }

        [Column("ra")]
        [SensitiveData]
        public string Ra { get; set; }


        [Column("email")]
        [SensitiveData]
        public string Email { get; set; }

        [Column("password")]
        [SensitiveData]
        public string Password { get; set; }

        [Column("phone")]
        [SensitiveData]
        public string Phone { get; set; }

        [Column("period")]
        public string Period { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<PatientRequest> PatientRequests { get; set; }
    }
}
