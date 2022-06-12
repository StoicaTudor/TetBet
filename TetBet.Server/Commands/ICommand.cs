namespace TetBet.Server.Commands
{
    public interface ICommand
    {
        bool CanExecute(string[] parameters);
        void Execute(string[] parameters);
    }
}