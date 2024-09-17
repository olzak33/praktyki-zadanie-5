using System.ComponentModel.DataAnnotations;

namespace zadanie5.Models
{
    public class Klienci
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(11)]
        public string PESEL { get; set; }

        [Required]
        public int BirthYear { get; set; }

        [Required]
        [StringLength(10)]
        public int Płeć { get; set; }
    }
}
