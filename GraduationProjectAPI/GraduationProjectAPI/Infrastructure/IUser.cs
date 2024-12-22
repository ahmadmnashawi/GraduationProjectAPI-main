using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IUser
    {
       
        public IQueryable<User> GetUsers { get; }
        public bool Save(User user);
        public void Update(User user);
        public void Delete(User user);
        public bool IsExisting(User user);
        public bool ChangePassword(string email, string password);
        public User SignIn(string email,string password);
    }
}
