namespace Abstraction.UnitOfWork;

public interface IUnitOfWorkFactory
{
    public IUnitOfWork Create();
}
