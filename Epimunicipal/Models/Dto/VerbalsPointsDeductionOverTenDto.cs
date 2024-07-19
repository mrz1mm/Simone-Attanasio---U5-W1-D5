namespace Epimunicipal.Models.Dto
{
    public class VerbalsPointsDeductionOverTenDto
    {
        public string FullName { get; set; }
        public DateTime ViolationDate { get; set; }
        public int PointDeduction { get; set; }
        public decimal Amount { get; set; }
    }
}
