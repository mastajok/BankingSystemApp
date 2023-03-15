using BankingSystem.Data.Entities;
using BankingSystem.DataAccess.Repositories;
using Xunit;

namespace BankingSystem.UnitTests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void GetAllUsersTest()
        {
            using (var context = new BankingSystemInMemoryDbContext())
            {
                context.Users.Add(new User() { Email = "john.doe@gmail.com", FirstName = "John", LastName = "Doe" });
                context.Users.Add(new User() { Email = "earl.simmons@gmail.com", FirstName = "Earl", LastName = "Simmons" });
                context.Users.Add(new User() { Email = "corey.tailor@gmail.com", FirstName = "Corey", LastName = "Tailor" });
                context.Users.Add(new User() { Email = "fred.durst@gmail.com", FirstName = "Fred", LastName = "Durst" });
                context.SaveChanges();
            }

            using (var context = new BankingSystemInMemoryDbContext())
            {

                var userRepository = new UserRepository(context);
                var users = userRepository.GetAll().GetAwaiter().GetResult();

                Assert.NotEmpty(users);
            }
        }

        [Fact]
        public void CreateUserTest()
        {
            var userEmail = "john.doe@gmail.com";

            using (var context = new BankingSystemInMemoryDbContext())
            {
                var userRepository = new UserRepository(context);

                userRepository.Create(new User()
                { Email = userEmail, FirstName = "John", LastName = "Doe" }).GetAwaiter().GetResult();

                var user = context.Users.SingleOrDefault(x => x.Email == userEmail);

                Assert.NotNull(user);

            }
        }

        [Fact]
        public void DeleteUserTest()
        {
            var userEmail = "frank.thompson@gmail.com";

            using (var context = new BankingSystemInMemoryDbContext())
            {
                context.Users.Add(new User() { Email = userEmail, FirstName = "Frank", LastName = "Thompson" });

                context.SaveChanges();

                var userRepository = new UserRepository(context);

                var user = userRepository.GetUser(userEmail).GetAwaiter().GetResult();

                userRepository.Delete(user.Email).GetAwaiter().GetResult();

                var sameUser = context.Users.SingleOrDefault(x => x.Email == userEmail);

                Assert.Null(sameUser);
            }
        }

    }
}
