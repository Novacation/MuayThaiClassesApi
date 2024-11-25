using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuayThaiClassesApi.Infra.Entities
{
    public class ClassesEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Master { get; set; }
        [Required]
        public required DateTime StartsAt { get; set; }
        [Required]
        public required DateTime EndsAt { get; set; }
        [Required]
        public required string Days { get; set; }
        [Required]
        public required double Price { get; set; }
    }
}