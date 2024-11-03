namespace OperationService.ViewModels;

public class AccountViewModel
{
    public int AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal OpeningBalance { get; set; }
    public bool Status { get; set; }
    public int ClientId { get; set; }
}