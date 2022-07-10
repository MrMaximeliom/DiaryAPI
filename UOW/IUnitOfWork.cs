using DiaryAPI.Services;
using DiaryAPI.Models;


namespace DiaryAPI.UOW
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<User> Users { get; }   
        IBaseRepository<Note> Notes { get; }

        int Complete();
    }
}
