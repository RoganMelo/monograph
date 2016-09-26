public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly UnitOfWork unitOfWork;
    protected readonly ISession session;

    public Repository(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = (UnitOfWork)unitOfWork;
        session = this.unitOfWork.GetSession();
    }

    public Task CreateAsync(TEntity obj)
    {
        session.Save(obj);
        return Task.FromResult(0);
    }

    public Task UpdateAsync(TEntity obj)
    {
        session.Update(obj);
        return Task.FromResult(0);
    }

    public Task DeleteAsync(TEntity obj)
    {
        session.Delete(obj);
        return Task.FromResult(0);
    }

    public void Dispose()
    {
        unitOfWork.Dispose();
    }
}
