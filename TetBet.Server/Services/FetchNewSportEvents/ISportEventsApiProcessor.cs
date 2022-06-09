namespace TetBet.Server.Services.FetchNewSportEvents
{
    public interface ISportEventsApiProcessor
    {
        void Process(string sportName);
    }
}