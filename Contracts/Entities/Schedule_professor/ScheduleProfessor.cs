using Contracts.Entities.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("schedule_professor")]
    public partial class ScheduleProfessor
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int id { get; set; }

        [Column("id_schedule")]
        public int idSchedule { get; set; }

        [Column("id_professor")]
        public int idProfessor { get; set; }

    }
}
