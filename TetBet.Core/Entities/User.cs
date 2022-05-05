namespace TetBet.Core.Entities
{
    public abstract class User
    {
        public long Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public AccountDetails AccountDetails { get; set; }
    }
}
