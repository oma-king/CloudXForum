namespace CloudXForum.DataAccess;

public interface IUnitOfWork
{
    Task Commit();
}