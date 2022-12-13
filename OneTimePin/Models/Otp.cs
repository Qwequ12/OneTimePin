using System.ComponentModel.DataAnnotations;

namespace OneTimePin.Models
{
    public class Otp
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string studentid { get; set; }
        public int pin{ get; set;}
        public DateTime created { get; set; }
    }
}
