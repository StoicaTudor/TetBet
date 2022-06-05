namespace TetBet.Server.Commands
{
    public interface ICommand
    {
        bool CanExecute();
        void Execute(string[] parameters);
    }
}