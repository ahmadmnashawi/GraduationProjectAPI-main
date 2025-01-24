using GraduationProjectAPI.Dto;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IUserAccessibility
    {
        public UserAccessibility GetUserAccessibility(int id);
        public IQueryable<UserAccessibility> GetUserAccessibilities { get; }
        public bool Save(UserAccessibility userAccessibility);
        public void Update(UserAccessibility userAccessibility);
        public void Delete(int idAccessibility, int idUser, string type, int id);
        public List<AccessibilityDto> getUserAccessibilities(int IdUser);
    }
}
