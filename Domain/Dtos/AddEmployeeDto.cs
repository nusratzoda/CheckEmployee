namespace Domain.Dtos;

public class AddEmployeeDto
{
     public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName{ get; set; }
    public DateTime BirthDate { get; set; }
    public bool Gender { get; set; }
    public string? Conditions { get; set; }
    public int Salary { get; set; }
    public string? Address { get; set; }
    public string? Member { get; set; }
    public string? FormerWork { get; set; }
}
