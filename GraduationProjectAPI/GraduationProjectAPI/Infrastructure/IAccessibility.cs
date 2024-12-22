using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IAccessibility
    {
        public Accessibility GetAccessibility(int id);
        public IQueryable<Accessibility> GetAccessibilties { get; }
        public bool Save(Accessibility accessibility);
        public void Update(Accessibility accessibility);
        public void Delete(Accessibility accessibility);
        public bool DeleteUserAccessibility(int IdUser, string access);
    }
}
