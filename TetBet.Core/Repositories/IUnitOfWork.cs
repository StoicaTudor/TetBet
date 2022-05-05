namespace TetBet.Core.Repositories
{
    public interface IUnitOfWork<TEntity>
    {
        IRepository<TEntity> Entities { get; }
        void Commit();
    }
}