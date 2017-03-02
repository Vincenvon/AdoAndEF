using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class Person
    {
        [HiddenInput(DisplayValue =false)]
        public int ID { get; set; }
        [Required(ErrorMessage ="Please enter FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter LastName")]
        public string LastName { get; set; }
        [Required]
        [Range(0,150,ErrorMessage ="Please enter positive age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter Sex")]
        public string Sex { get; set; }
        
    }
}
