using ZeOrganizeBack.Models;

namespace ZeOrganizeBack.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Users!.Any() || context.Events!.Any())
            {
                return;
            }

            var users = new List<UserModel>
            {
                new UserModel
                {
                    Name = "Cheng wei",
                    LastName = "Chin",
                    Email = "cheng@email.com",
                    Password = "1234",
                    PhoneNumber = "(12) 12345-6789"
                }
            };

            context.AddRange(users);

            var events = new List<EventModel>
            {

            };

            context.AddRange(events);

            context.SaveChanges();
        }
    }
}
