using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities {
    [Table("schedule")]
    public partial class Schedule
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}
