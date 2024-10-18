using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.Insurance
{
    [Table("InsuranceProviders", Schema = "Insurance")]
    public class InsuranceProviders : BaseEntity
    {
        [Key]
        private int InsuranceProviderID { get; set; }
        private string? Name { get; set; }
        private string? ContactNumber { get; set; }
        private string? Email { get; set;}
        private string? Website { get; set;}
        private string? Address { get; set; }
        private string? City { get; set; }
        private string? State { get; set; }
        private string? Country { get; set;}
        private string? ZipCode { get; set; }
        private string? CoverageDetails { get; set; }
        private string? LogoUrl { get; set; }
        private bool IsPreferred { get; set; }
        private int NetworkTypeId { get; set; }
        private string? CustomerSupportContact {  get; set; }
        private string? AcceptedRegions { get; set; }
        private decimal MaxCoverageAmount { get; set; }
    }
}
