using System;
using System.ComponentModel.DataAnnotations;

namespace Epimunicipal.Models.Dto
{
    public class VerbalDto
    {
        [Required(ErrorMessage = "Il trasgressore è obbligatorio")]
        [Display(Name = "Trasgressore")]
        public int PersonalDataId { get; set; }

        [Required(ErrorMessage = "Il tipo di violazione è obbligatorio")]
        [Display(Name = "Tipo di Violazione")]
        public int ViolationTypeId { get; set; }

        [Required(ErrorMessage = "La data della violazione è obbligatoria")]
        [Display(Name = "Data Violazione")]
        [DataType(DataType.Date)]
        public DateTime ViolationDate { get; set; }

        [Required(ErrorMessage = "L'indirizzo della violazione è obbligatorio")]
        [Display(Name = "Indirizzo Violazione")]
        public string ViolationAddress { get; set; }

        [Required(ErrorMessage = "Il nome dell'agente è obbligatorio")]
        [Display(Name = "Nome Agente")]
        public string AgentName { get; set; }

        [Required(ErrorMessage = "La data del verbale è obbligatoria")]
        [Display(Name = "Data Verbale")]
        [DataType(DataType.Date)]
        public DateTime VerbalDate { get; set; }

        [Required(ErrorMessage = "L'importo è obbligatorio")]
        [Display(Name = "Importo")]
        [Range(0.01, double.MaxValue, ErrorMessage = "L'importo deve essere maggiore di zero")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "La decurtazione dei punti è obbligatoria")]
        [Display(Name = "Decurtazione Punti")]
        [Range(0, int.MaxValue, ErrorMessage = "La decurtazione dei punti deve essere un valore positivo")]
        public int PointDeduction { get; set; }
    }
}
