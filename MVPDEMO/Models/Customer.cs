using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    //create a class called Customer and add properties to it with some model validation
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Range(18,99)]
        public int Age { get; set; }
    }
}
