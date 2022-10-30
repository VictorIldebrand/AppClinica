using Contracts.Entities.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("notification")]
    public partial class notification
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int id { get; set; }

        [Column("id_student")]
        public int idStudent { get; set; }


        [Column("id_patient")]
        public int idPatient { get; set; }

        [Column("status")]
        [Required]
        public int status { get; set; }

        [Column("message")]
        [Required]
        public String message { get; set; }
    }
}
