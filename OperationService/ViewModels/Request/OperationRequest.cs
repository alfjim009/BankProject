namespace OperationService.ViewModels.Request;

public class OperationRequest
{
    [Required]
    public bool IsDeposit { get; set; }

    [Required]
    public decimal Value { get; set; }

    [Required]
    public int AccountId { get; set; }
}