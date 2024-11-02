namespace OperationService.Models;

public class Accounts
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string AccountNumber { get; set; }

    [Required]
    [MaxLength(50)]
    public string AccountType { get; set; }

    [Required]
    public decimal OpeningBalance { get; set; }

    public bool Status { get; set; }

    [Required]
    public int ClientId { get; set; }

    public ICollection<Operations> Operations { get; set; }
}