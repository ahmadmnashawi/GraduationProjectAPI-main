using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
namespace GraduationProjectAPI.Data
{
    public class WriterRepo:IWriter
    {
        private readonly GraduationProjectDbContext _db;
        public WriterRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Writer> GetWriters => _db.Writers;

        public void Delete(Writer Writer)
        {
            var writer = _db.Writers.FirstOrDefault(p => p.Id == Writer.Id);
            if (writer != null)
            {
                var bookwriter = _db.BookWriters.Where(p => p.IdWriter == writer.Id && p.IsDeleted==false).ToList();
                if(bookwriter.Count != 0)
                {
                    foreach(BookWriter e in bookwriter)
                    {
                        e.IsDeleted = true;
                    }
                    _db.SaveChanges();
                }
                //_db.Writers.Remove(writer);
                writer.IsDeleted = true;
                _db.SaveChanges();
            }


        }
        public Writer GetWriter(int id)
        {
            var writer = _db.Writers.FirstOrDefault(p => p.Id == id);
            if (writer != null)
                return writer;
            else
                return null;

        }
        public bool Save(Writer writer)
        {
            if (writer.Id == 0)
            {
                if (!IsExisting(writer))
                {
                    _db.Writers.Add(writer);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void Update(Writer writer)
        {
            var Writer = _db.Writers.FirstOrDefault(p => p.Id == writer.Id);
            if (Writer != null)
            {
                Writer.writerName = writer.writerName;
                Writer.IsDeleted = writer.IsDeleted;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(Writer writer)
        {
            var data = _db.Writers.Any(p => p.writerName.Equals(writer.writerName));
            // var data = _db.Contents.Where(u => string.Equals(u.typeName, content.typeName, StringComparison.CurrentCultureIgnoreCase));
            if (data == false)
            {
                return false;
            }
            else return true;
        }
    }
}
