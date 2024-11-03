namespace UserService.Models;

public class Persons
{
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string Name { get; set; }

  [Required]
  public Gender Gender { get; set; }

  [Required]
  public int Age { get; set; }

  [Required]
  [MaxLength(50)]
  public string Identificacion { get; set; }

  [MaxLength(100)]
  public string Address { get; set; }

  [MaxLength(100)]
  public string Phone { get; set; }
}

public enum Gender
{
  Male,
  Female,
  Other,
  Unknown
}