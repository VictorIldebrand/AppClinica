using Contracts.Entities.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("professor")]
    public partial class Professor
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int id { get; set; }

        [Column("email")]
        [SensitiveData]
        public string email { get; set; }

        [Column("password")]
        [SensitiveData]
        public string password { get; set; }

        [Column("name")]
        [SensitiveData]
        public string name { get; set; }

        [Column("rp")]
        [SensitiveData]
        public string rp { get; set; }

        [Column("phone")]
        [SensitiveData]
        public string phone { get; set; }

        [Column("active")]
        public bool active { get; set; }
    }
}
