using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCUITemplate.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(8)]
        public string? Title { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(128)]
        public string? CompanyName { get; set; }

        [Required, StringLength(100), EmailAddress]
        public string? EmailAddress { get; set; }

        [StringLength(50)]
        public string? Phone { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RowGuid { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
