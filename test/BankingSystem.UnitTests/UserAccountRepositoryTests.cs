using BankingSystem.Data.Entities;
using BankingSystem.DataAccess.Repositories;
using Xunit;

namespace BankingSystem.UnitTests
{
    public class UserAccountRepositoryTests
    {

        [Fact]
        public void GetUsersAccounts()
        {
            var userEmail = "john1.doe1@gmail.com";

            User user;

            using (var context = new BankingSystemInMemoryDbContext())
            {
                context.Users.Add(new User() { Email = userEmail, FirstName = "John1", LastName = "Doe1" });
                context.SaveChanges();

                user = context.Users.SingleOrDefault(x => x.Email == userEmail);

                Assert.NotNull(user);

                context.AddRange(new List<UserAccount>()
                {
                    new() { AccountName = "John1's 1st account", UserId = user.Id },
                    new() { AccountName = "John1's 2st account", UserId = user.Id },
                    new() { AccountName = "John1's 3st account", UserId = user.Id }
                });

                context.SaveChanges();

                var userAccountRepository = new UserAccountRepository(context);

                var usersAccounts = userAccountRepository.GetUsersAccounts(user.Id).GetAwaiter().GetResult();

                Assert.NotEmpty(usersAccounts);

            }
        }



        [Fact]
        public void CreateUserAccountsTest()
        {

            var userEmail = "john.doe@gmail.com";

            User user;

            using (var context = new BankingSystemInMemoryDbContext())
            {
                var userRepository = new UserRepository(context);

                userRepository.Create(new User() { Email = userEmail, FirstName = "John", LastName = "Doe" })
                    .GetAwaiter().GetResult();

                user = context.Users.SingleOrDefault(x => x.Email == userEmail);

                Assert.NotNull(user);

                var userAccountRepository = new UserAccountRepository(context);

                userAccountRepository.CreateUserAccount(user.Id, "John's 1st account").GetAwaiter().GetResult();
                userAccountRepository.CreateUserAccount(user.Id, "John's 2nd account").GetAwaiter().GetResult();
                userAccountRepository.CreateUserAccount(user.Id, "John's 3rd account").GetAwaiter().GetResult();

                var userAccounts = context.UserAccounts.Where(x => x.UserId == user.Id).ToList();

                Assert.NotNull(userAccounts);

            }
        }


        [Fact]
        public void DeleteUserAccountsTest()
        {

            var userEmail = "harry.fischer@gmail.com";

            User user;

            using (var context = new BankingSystemInMemoryDbContext())
            {
                var userRepository = new UserRepository(context);

                userRepository.Create(new User() { Email = userEmail, FirstName = "Harry", LastName = "Fischer" })
                    .GetAwaiter().GetResult();

                user = context.Users.SingleOrDefault(x => x.Email == userEmail);

                Assert.NotNull(user);

                context.AddRange(new List<UserAccount>()
                {
                    new() { AccountName = "Harry's 1st account", UserId = user.Id },
                    new() { AccountName = "Harry's 2st account", UserId = user.Id },
                    new() { AccountName = "Harry's 3st account", UserId = user.Id }
                });

                context.SaveChanges();


                var userAccounts = context.UserAccounts.Where(x => x.UserId == user.Id).ToList();

                Assert.NotNull(userAccounts);
                Assert.Equal(3, userAccounts.Count);


                var userAccountToDelete = userAccounts.First();
                var userAccountRepository = new UserAccountRepository(context);

                userAccountRepository.DeleteUserAccount(user.Id, userAccountToDelete.Id).GetAwaiter().GetResult();


                var userAccountsAfterDeletion = context.UserAccounts.Where(x => x.UserId == user.Id).ToList();

                var deletedUserAccount = userAccountsAfterDeletion.FirstOrDefault(x => x.Id == userAccountToDelete.Id);

                Assert.Null(deletedUserAccount);
            }



        }
    }
}
