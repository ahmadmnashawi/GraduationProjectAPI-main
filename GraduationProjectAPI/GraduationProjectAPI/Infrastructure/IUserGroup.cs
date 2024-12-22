using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IUserGroup
    {
        public UserGroup GetUserGroup(int id);
        public IQueryable<UserGroup> GetUserGroups { get; }
        public bool Save(UserGroup userGroup);
        public void Update(UserGroup userGroup);
        public void Delete(UserGroup userGroup);

    }
}
