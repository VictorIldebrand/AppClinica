using Contracts.Entities.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("notification")]
    public partial class Notification
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("id_student")]
        public int IdStudent { get; set; }

        [Column("id_patient")]
        public int IdPatient { get; set; }

        [Column("id_employee")]
        public int IdEmployee { get; set; }

        [Column("read")]
        [Required]
        public Boolean Read { get; set; }

        [Column("message")]
        [Required]
        public String Message { get; set; }
    }
}
