using Enter.Dashboard.Model;

namespace Enter.Dashboard
{
    public static class Constants
    {
        public static Roles DeveloperRole = new Roles()
        {
            Id = Guid.NewGuid(),
            Title = "برنامه نویس",
            Value = "Developer",
            Icon = "fa-light fa-users",
            Childrens = new List<Roles> {
                new Roles()
                {
                    Id = Guid.NewGuid(),
                    Title = "برنامه نویس تازه کار",
                    Value = "Junior Developer",
                    Icon = "fa-light fa-users",
                },
                 new Roles()
                {
                    Id = Guid.NewGuid(),
                    Title = "برنامه نویس نرمال",
                    Value = "Normal Developer",
                    Icon = "fa-light fa-users",
                    Childrens = new List<Roles> {
                        new Roles()
                        {
                            Id = Guid.NewGuid(),
                            Title = "برنامه نویس نرمال فرانت",
                            Value = "Normal Front Developer",
                            Icon = "fa-light fa-home",
                        },
                        new Roles()
                        {
                            Id = Guid.NewGuid(),
                            Title = "برنامه نویس نرمال بکاند",
                            Value = "Normal Backend Developer",
                            Icon = "fa-light fa-note",
                        },
                    }
                },
                new Roles()
                {
                    Id = Guid.NewGuid(),
                    Title = "برنامه نویس حرفه ای",
                    Value = "Expert Developer",
                    Icon = "fa-light fa-close",
                }
            }
        };

        public static Roles AdminRole = new Roles()
        {
            Id = Guid.NewGuid(),
            Title = "ادمین",
            Value = "Admin",
            Icon = "fa-light fa-user"
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
