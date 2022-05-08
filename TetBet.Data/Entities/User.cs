namespace TetBet.Data.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AccountDetails AccountDetails { get; set; }
    }
}