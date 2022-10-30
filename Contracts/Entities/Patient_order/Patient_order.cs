using Contracts.Entities.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("patient_order")]
    public partial class Patient_order
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int id { get; set; }

        [Column("date_solicitation")]
        public DateTime dateSolicitation { get; set; }

        // [Column("status")]
        // [Required]
        // public StatusEnum status { get; set; }

        [Column("id_patient")]
        public int idPatient { get; set; }

        [Column("specialty")]
        public string specialty { get; set; }

        [Column("active")]
        public bool active { get; set; }
    }
}
