using System.ComponentModel.DataAnnotations;

namespace AVSoftTest.DAL.Models
{
    public class CounterEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Key { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
