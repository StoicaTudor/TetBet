namespace TetBet.Infrastructure.Entities
{
    public class User : Infrastructure.Entities.EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Infrastructure.Entities.AccountDetails AccountDetails { get; set; }
    }
}
