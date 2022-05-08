namespace TetBet.Core.Dtos.GetDtos
{
    public class UserGetDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public AccountDetailsGetDto AccountDetails { get; set; }
    }
}