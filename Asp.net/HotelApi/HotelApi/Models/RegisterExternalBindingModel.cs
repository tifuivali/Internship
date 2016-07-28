using System.ComponentModel.DataAnnotations;

namespace HotelApi_.Models
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}