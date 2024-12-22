using GraduationProjectAPI.Dto;
using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Data
{
    public class UserAccessibilityRepo: IUserAccessibility
    {
        private readonly GraduationProjectDbContext _db;
        public UserAccessibilityRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<UserAccessibility> GetUserAccessibilities => _db.UserAccessibilities;

        public void Delete(UserAccessibility UserAccessibility)
        {
            var userAccessibility = _db.UserAccessibilities.FirstOrDefault(p => p.Id == UserAccessibility.Id);
            if (userAccessibility != null)
            {
                _db.UserAccessibilities.Remove(userAccessibility);
                _db.SaveChanges();
            }


        }
        public UserAccessibility GetUserAccessibility(int id)
        {
            var userAccessibility = _db.UserAccessibilities.FirstOrDefault(p => p.Id == id);
            if (userAccessibility!= null)
                return userAccessibility;
            else
                return null;

        }
        public bool Save(UserAccessibility userAccessibility)
        {
            if (userAccessibility.Id == 0)
            {
                if (!IsExisting(userAccessibility))
                {
                    _db.UserAccessibilities.Add(userAccessibility);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void Update(UserAccessibility userAccessibility)
        {
            var UserAccessibility = _db.UserAccessibilities.FirstOrDefault(p => p.Id == userAccessibility.Id);
            if (UserAccessibility != null)
            {
                UserAccessibility.IdUser = userAccessibility.IdUser ;
                UserAccessibility.IdAccessibility = userAccessibility.IdAccessibility;
                UserAccessibility.IdGroup = userAccessibility.IdGroup;
                UserAccessibility.IdLibrary = userAccessibility.IdLibrary;
                UserAccessibility.IdReference = userAccessibility.IdLibrary;
                UserAccessibility.IdTest = userAccessibility.IdTest;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(UserAccessibility userAccessibility)
        {
            var data = _db.UserAccessibilities.Any(p => p.IdAccessibility == userAccessibility.IdAccessibility && p.IdUser == userAccessibility.IdUser);
            if (data != true)
            {
                return false;
            }
            else return true;
        }
        public List<AccessibilityDto> getUserAccessibilities(int IdUser)
        {
            List<AccessibilityDto> dto = new List<AccessibilityDto>();
            var user = _db.Users.FirstOrDefault(p => p.Id == IdUser);
            if (user != null)
            {
                List<UserAccessibility> userAccessibilities = _db.UserAccessibilities.Where(p => p.IdUser == IdUser).ToList();
                foreach (UserAccessibility e in userAccessibilities)
                {
                    Accessibility accessibility = _db.Accessibilities.FirstOrDefault(p => p.Id == e.IdAccessibility);
                    if (accessibility != null)
                    {
                        //AccessibilityDto accessibilityDto = new AccessibilityDto();
                        var group = _db.Groups.FirstOrDefault(p => p.Id == e.IdGroup);
                        var library = _db.Libraries.FirstOrDefault(p => p.Id == e.IdLibrary);
                        var test = _db.Tests.FirstOrDefault(p => p.Id == e.IdTest);
                        var refre = _db.References.FirstOrDefault(p => p.Id == e.IdReference);
                        if(group != null)
                        {
                            AccessibilityDto accessibilityDto = new AccessibilityDto();
                            accessibilityDto.Accessibility = accessibility;
                            accessibilityDto.Object = group;
                            accessibilityDto.type = "Group";
                            dto.Add(accessibilityDto);
                        }
                        if (library != null)
                        {
                            AccessibilityDto accessibilityDto = new AccessibilityDto();
                            accessibilityDto.Accessibility = accessibility;
                            accessibilityDto.Object = library;
                            accessibilityDto.type = "Library";
                            dto.Add(accessibilityDto);
                        }
                        if(test != null)
                        { 
                            AccessibilityDto accessibilityDto = new AccessibilityDto();
                            accessibilityDto.Accessibility = accessibility;
                            accessibilityDto.Object = test;
                            accessibilityDto.type = "Test";
                             dto.Add(accessibilityDto);
                        }
                        if (refre != null)
                        {
                            AccessibilityDto accessibilityDto = new AccessibilityDto();
                            accessibilityDto.Accessibility = accessibility;
                            accessibilityDto.Object = refre;
                            accessibilityDto.type = "Reference";
                            dto.Add(accessibilityDto);
                        }
                    }
                }
                if (dto.Count != 0)
                {
                    return dto;
                }
                else return null;
            }
            else
            {
                return null;
            }
            
        }
    }
}
