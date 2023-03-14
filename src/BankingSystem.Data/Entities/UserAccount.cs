namespace BankingSystem.Data.Entities
{
    public class UserAccount
    {
        public int Id { get; set; }
        public decimal CurrentBalance { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
