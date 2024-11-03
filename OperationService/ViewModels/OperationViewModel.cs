namespace OperationService.ViewModels;

public class OperationViewModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool IsDeposit { get; set; }
    public decimal Value { get; set; }
    public decimal Balance { get; set; }
    public int AccountId { get; set; }
    public Accounts Account { get; set; }
}