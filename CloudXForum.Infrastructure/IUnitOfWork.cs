namespace CloudXForum.Infrastructure;

public interface IUnitOfWork
{
    Task Commit();
}