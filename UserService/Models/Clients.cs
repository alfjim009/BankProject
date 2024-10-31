using System.ComponentModel.DataAnnotations;

namespace UserService.Models;

public class Clients : Persons
{
  public int ClientId { get; set; }

  [Required]
  [MaxLength(100)]
  public string Password { get; set; }

  public bool Status { get; set; }
}