using Enter.Dashboard.Model;

namespace Enter.Dashboard;

public static class Constants
{
    private static readonly Guid id = Guid.NewGuid();

    public static Roles DeveloperRole = new()
    {
        Id = id,
        Text = "Developer",
        Value = "Developer",
        Childrens = new List<Roles>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Text = "Junior Developer",
                Value = "Junior Developer",
                ParentId = id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Text = "Middle Developer",
                Value = "Normal Developer",
                Childrens = new List<Roles>
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Text = "Normal Front Developer",
                        Value = "Normal Front Developer"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Text = "Normal Backend Developer",
                        Value = "Normal Backend Developer"
                    }
                },
                ParentId = id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Text = "Expert Developer",
                Value = "Expert Developer",
                ParentId = id
            }
        }
    };


    public static Roles AdminRole = new()
    {
        Id = Guid.NewGuid(),
        Text = "Admin",
        Value = "Admin"
    };

    public static List<Roles> Roles = new()
    {
        AdminRole,
        DeveloperRole
    };

    public static List<Roles> RawRoles = new()
    {
        AdminRole,
        DeveloperRole,
        new Roles()
        {
            Id = Guid.NewGuid(),
            Text = "Junior Developer",
            Value = "Junior Developer",
            ParentId = id
        }
    };

    public static List<Users> Users = new()
    {
        new Users()
        {
            Id = Guid.NewGuid(),
            FirstName = "اکبر",
            LastName = "احمدی سرای",
            Age = 28,
            Role = AdminRole
        },
        new Users()
        {
            Id = Guid.NewGuid(),
            FirstName = "وحید",
            LastName = "رسولی",
            Age = 35,
            Role = AdminRole
        },
        new Users()
        {
            Id = Guid.NewGuid(),
            FirstName = "هادی",
            LastName = "احمدی سرای",
            Age = 23,
            Role = DeveloperRole
        },
        new Users()
        {
            Id = Guid.NewGuid(),
            FirstName = "مسعود",
            LastName = "خدادی",
            Age = 23,
            Role = DeveloperRole
        }
    };
}