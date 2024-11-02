namespace OperationService.ViewModels.Request;

public class AccountRequest
{
    [Required]
    [MaxLength(50)]
    public string AccountType { get; set; }

    [Required]
    public decimal OpeningBalance { get; set; }

    [Required]
    public int ClientId { get; set; }
}