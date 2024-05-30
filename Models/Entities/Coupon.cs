using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Coupon
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Code is required")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Code must be exactly 10 characters long")]
    public string Code { get; set; }

    [Required(ErrorMessage = "Discount amount is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Discount amount must be a positive number")]
    public decimal DiscountAmount { get; set; }

    [Required(ErrorMessage = "Expiration date is required")]
    [DataType(DataType.Date)]
    public DateTime ExpirationDate { get; set; }

    public List<Package> Packages { get; set; } 

    [Required]
    public DateTime CreatedAt { get; set; }

    public User? CreatedBy { get; set; }

    [Required]
    public DateTime LastModifiedAt { get; set; }

    public User? LastModifiedBy { get; set; }

    [NotMapped]
    public string? FormattedDiscountAmount
    {
        get { return DiscountAmount.ToString("F3") + " DT"; }
    }

    public Coupon()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        LastModifiedAt = CreatedAt;
        Packages = new List<Package>(); 
    }
}