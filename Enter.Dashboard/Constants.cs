using Enter.Dashboard.Model;

namespace Enter.Dashboard
{
    public static class Constants
    {
        public static Roles DeveloperRole = new Roles()
        {
            Id = Guid.NewGuid(),
            Title = "برنامه نویس",
            Value = "Developer"
        };

        public static Roles AdminRole = new Roles()
        {
            Id = Guid.NewGuid(),
            Title = "ادمین",
            Value = "Admin"
        };

        public static List<Roles> Roles = new List<Roles>()
        {
            AdminRole,
            DeveloperRole
        };

        public static List<Users> Users = new List<Users>()
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
}
