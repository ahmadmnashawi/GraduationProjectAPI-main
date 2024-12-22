using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IUserReference
    {
        public UserReference GetUserReference(int id);
        public IQueryable<UserReference> GetUserReferences { get; }
        public bool Save(UserReference userReference);
        public void Update(UserReference userReference);
        public void Delete(UserReference userReference);
    }
}
