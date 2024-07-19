using System.ComponentModel.DataAnnotations;

namespace Epimunicipal.Models.Dto
{
    public class PersonalDataDto
    {
        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [Display(Name = "Cognome")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "L'indirizzo è obbligatorio")]
        [Display(Name = "Indirizzo")]
        public string Address { get; set; }

        [Required(ErrorMessage = "La città è obbligatoria")]
        [Display(Name = "Città")]
        public string City { get; set; }

        [Required(ErrorMessage = "Il CAP è obbligatorio")]
        [Display(Name = "CAP")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Il CAP deve essere un numero di 5 cifre")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [Display(Name = "Codice Fiscale")]
        [StringLength(16, ErrorMessage = "Il codice fiscale deve essere di 16 caratteri")]
        public string TaxIdCode { get; set; }
    }
}