using Contracts.Entities.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("schedule")]
    public partial class Schedule
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int id { get; set; }

        [Column("name")]
        [SensitiveData]
        public string name { get; set; }

        [Column("active")]
        public bool active { get; set; }
    }
}
