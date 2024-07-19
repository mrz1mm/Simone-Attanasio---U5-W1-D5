namespace Epimunicipal.Models.Dto
{
    public class VerbalDetailsDto
    {
        public string TransgressorFullName { get; set; }
        public string ViolationTypeDescription { get; set; }
        public DateTime ViolationDate { get; set; }
        public string ViolationAddress { get; set; }
        public string AgentName { get; set; }
        public DateTime VerbalDate { get; set; }
        public decimal Amount { get; set; }
        public int PointDeduction { get; set; }
    }
}
