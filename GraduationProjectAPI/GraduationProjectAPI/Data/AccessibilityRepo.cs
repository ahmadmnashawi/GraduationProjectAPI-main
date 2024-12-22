using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Data
{
    public class AccessibilityRepo : IAccessibility
    {
        private readonly GraduationProjectDbContext _db;
        public AccessibilityRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Accessibility> GetAccessibilties => _db.Accessibilities;

        public void Delete(Accessibility Accessibility)
        {
            var accessibility = _db.Accessibilities.FirstOrDefault(p => p.Id == Accessibility.Id);
            if (accessibility != null)
            {
                List<UserAccessibility> UserAccessibility = _db.UserAccessibilities.Where(p => p.IdAccessibility == accessibility.Id).ToList();
                if(UserAccessibility != null)
                {
                    _db.UserAccessibilities.RemoveRange(UserAccessibility);
                    _db.SaveChanges();
                }
                _db.Accessibilities.Remove(accessibility);
                _db.SaveChanges();
            }


        }
        public Accessibility GetAccessibility(int id)
        {
            var accessibility = _db.Accessibilities.First(p => p.Id == id);
            if (accessibility != null)
                return accessibility;
            else
                return null;

        }
        public bool Save(Accessibility accessibility)
        {
            if (accessibility.Id == 0)
            {
                if ( !IsExisiting(accessibility.AccessibilityType))
                {
                    _db.Accessibilities.Add(accessibility);
                    _db.SaveChanges();
                }
                return true;
            }
            return false;
        }
        public void Update(Accessibility accessibility)
        {
            var Accessibility = _db.Accessibilities.First(p => p.Id == accessibility.Id);
            if (Accessibility != null)
            {
                Accessibility.AccessibilityType = accessibility.AccessibilityType;
                _db.SaveChanges();
            }
        }
        public bool DeleteUserAccessibility(int IdUser, string access)
        {
            var Accessibility = _db.Accessibilities.FirstOrDefault(p => p.AccessibilityType == access);
            if (Accessibility != null)
            {
                var data = _db.UserAccessibilities.FirstOrDefault(p => p.IdUser == IdUser && p.IdAccessibility == Accessibility.Id);
                if (data != null)
                {
                    _db.UserAccessibilities.Remove(data);
                    _db.SaveChanges();
                    return true;
                }
                else  return false;
            }
            else
            {
                return false;
            }
        }
        public bool IsExisiting(string name)
        {
            var data = _db.Accessibilities.Any(p => p.AccessibilityType.Equals(name));
            // var data = _db.Contents.Where(u => string.Equals(u.typeName, content.typeName, StringComparison.CurrentCultureIgnoreCase));
            if (data == false)
            {
                return false;
            }
            else return true;
        }
    }
}
