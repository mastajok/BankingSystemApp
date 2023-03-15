namespace BankingSystem.Data.Entities
{
    public class UserAccount
    {
        public int Id { get; set; }

        public decimal CurrentBalance { get; set; } = 0;

        public int UserId { get; set; }

        public string AccountName { get; set; }

    }
}
