using Contracts.Entities.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("user")]
    public partial class User
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [SensitiveData]
        public string Name { get; set; }

        [Column("email")]
        [SensitiveData]
        public string Email { get; set; }

        [Column("password")]
        [SensitiveData]
        public string Password { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}
