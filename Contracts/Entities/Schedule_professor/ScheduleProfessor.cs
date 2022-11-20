using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities {
    [Table("schedule_professor")]
    public partial class ScheduleProfessor
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("id_schedule")]
        public Schedule Schedule { get; set; }

        [Column("id_professor")]
        public Professor Professor { get; set; }

    }
}
