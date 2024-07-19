namespace Epimunicipal.Models
{
    public class Verbal
    {
        public int VerbalId { get; set; }
        public int PersonalDataId { get; set; }
        public int ViolationTypeId { get; set; }
        public DateTime ViolationDate { get; set; }
        public string ViolationAddress { get; set; }
        public string AgentName { get; set; }
        public DateTime VerbalDate { get; set; }
        public decimal Amount { get; set; }
        public int PointDeduction { get; set; }
    }
}
