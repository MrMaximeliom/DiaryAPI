using DiaryAPI.Services;
using DiaryAPI.Data;
using DiaryAPI.Models;


namespace DiaryAPI.UOW

{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public IBaseRepository<User> Users { get; private set; }
        public IBaseRepository<Note> Notes { get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Users = new BaseRepository<User>(_context);
            Notes = new BaseRepository<Note>(_context);

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}
