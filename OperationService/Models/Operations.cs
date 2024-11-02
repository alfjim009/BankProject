namespace OperationService.Models;

public class Operations
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool IsDeposit { get; set; }

    [Required]
    public decimal Value { get; set; }

    public decimal Balance { get; set; }
    public int AccountId { get; set; }
    public Accounts Account { get; set; }
}