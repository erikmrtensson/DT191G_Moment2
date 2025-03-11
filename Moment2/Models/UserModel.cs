using System.ComponentModel.DataAnnotations;

namespace Moment2.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Namn är obligatoriskt")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Ålder är obligatoriskt")]
        [Range(13, 120, ErrorMessage = "Ålder måste vara mellan 13 och 100")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Email är obligatoriskt")]
        [EmailAddress(ErrorMessage = "Ogiltig emailadress")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Välj Utbildning")]
        public string? Program { get; set; }


        [Required(ErrorMessage = "Välj vilket år du läser")]
        public string? Year { get; set; }
    }
}
