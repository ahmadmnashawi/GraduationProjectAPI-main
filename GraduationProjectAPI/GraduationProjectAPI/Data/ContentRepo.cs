using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
   namespace GraduationProjectAPI.Data
   {
    public class ContentRepo : IContent
    {
        private readonly GraduationProjectDbContext _db;
        public ContentRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Content> GetContents => _db.Contents;

        public void Delete(Content content)
        {
            var type = _db.Contents.FirstOrDefault(p => p.Id == content.Id);
            if (type != null)
            {
                var refre = _db.References.Where(p => p.IdContent == type.Id).ToList();
                var test = _db.Tests.Where(p => p.IdContent == type.Id).ToList();
                var post = _db.Posts.Where(p => p.IdContent == type.Id).ToList();
                var group = _db.Groups.Where(p => p.IdContent == type.Id).ToList();
                if(refre.Count != 0)
                {
                    _db.References.RemoveRange(refre);
                    _db.SaveChanges();
                }
                if (test.Count != 0)
                {
                    _db.Tests.RemoveRange(test);
                    _db.SaveChanges();
                }
                if (post.Count != 0)
                {
                    _db.Posts.RemoveRange(post);
                    _db.SaveChanges();
                }
                if (group.Count != 0)
                {
                    _db.Groups.RemoveRange(group);
                    _db.SaveChanges();
                }
                _db.Contents.Remove(type);
                _db.SaveChanges();
            }
        }
        public Content GetContent(int id)
        {
            var type = _db.Contents.FirstOrDefault(p => p.Id == id);
            if (type != null)
                return type;
            else
                return null;

        }
        public bool Save(Content type)
        {
            //var data = _db.Contents.Where(p => p.typeName == type.typeName);
            if (type.Id == 0)
            {
                if (!IsExisting(type))
                {
                    _db.Contents.Add(type);
                    _db.SaveChanges();
                    return true;
                }
                else return false;
            }
           else  return false;
        }
        public void Update(Content type)
        {
            var Type = _db.Contents.FirstOrDefault(p => p.Id == type.Id);
            if (Type != null)
            {
                Type.typeName = type.typeName;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(Content content)
        {
            var data = _db.Contents.Any(p => p.typeName.Equals(content.typeName));
            // var data = _db.Contents.Where(u => string.Equals(u.typeName, content.typeName, StringComparison.CurrentCultureIgnoreCase));
            if (data == false)
            {
                return false;
            }
            else return true;
        }
    }
   }
