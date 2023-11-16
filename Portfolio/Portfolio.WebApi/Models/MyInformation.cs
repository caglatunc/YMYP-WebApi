namespace Portfolio.WebApi.Models;

public sealed class MyInformation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Adress { get; set; }
    public string Description { get; set; }
}

public class MyInformationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }
}
