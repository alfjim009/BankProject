namespace UserService.ViewModels.Request;

public class PersonUpdateRequest
{
    public string Name { get; set; }

    public Gender Gender { get; set; }

    public int Age { get; set; }

    public string Identificacion { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }
}