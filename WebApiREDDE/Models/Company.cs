using System.ComponentModel.DataAnnotations;

namespace WebApiREDDE.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(9)]
        public string RNC { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CommercialName { get; set; }
        public string Category { get; set; }
        [Required]
        public string PaymentScheme { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string EconomicActivity { get; set; }
        [Required]
        public string GubernamentalBranch { get; set; }

    }
}
