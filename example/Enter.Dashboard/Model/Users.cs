namespace Enter.Dashboard.Model;

public class Users
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Name => $"{FirstName} {LastName}";
    public int Age { get; set; }
    public Roles Role { get; set; }
}