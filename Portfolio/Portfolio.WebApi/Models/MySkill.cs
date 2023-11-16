namespace Portfolio.WebApi.Models;

public sealed class MySkill
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }
}

public class MySkillDto
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }
}
