using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
namespace GraduationProjectAPI.Data
{
    public class UserRepo:IUser
    {
        private readonly GraduationProjectDbContext _db;
        public UserRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<User> GetUsers => _db.Users;

        public void Delete(User User)
        {
            var user = _db.Users.FirstOrDefault(p => p.Id == User.Id);
            if (user != null)
            {
                var userRefre = _db.UserReferences.Where(p => p.IdUser == user.Id).ToList();
                var Complaint = _db.Complaints.Where(p => p.IdUser == user.Id).ToList();
                var gameUser = _db.GameUsers.Where(p => p.IdUser == user.Id).ToList();
                var buybook = _db.Buybooks.Where(p => p.IdUser == user.Id).ToList();
                var userPost = _db.UserPosts.Where(p => p.IdUser == user.Id).ToList();
                var post = _db.Posts.Where(p => p.IdUser == user.Id).ToList();
                var usergroup = _db.UserGroups.Where(p => p.IdUser == user.Id).ToList();
                var follow = _db.Follows.Where(p => p.followedId == user.Id || p.followId == user.Id).ToList();
                var comment = _db.Comments.Where(p => p.IdUser == user.Id).ToList();
                var userAccess = _db.UserAccessibilities.Where(p => p.IdUser == user.Id).ToList();
                if(userRefre.Count != 0)
                {
                    _db.UserReferences.RemoveRange(userRefre);
                    _db.SaveChanges();
                }
                if (Complaint.Count != 0)
                {
                    _db.Complaints.RemoveRange(Complaint);
                    _db.SaveChanges();
                }
                if (gameUser.Count != 0)
                {
                    _db.GameUsers.RemoveRange(gameUser);
                    _db.SaveChanges();
                }
                if (buybook.Count != 0)
                {
                    _db.Buybooks.RemoveRange(buybook);
                    _db.SaveChanges();
                }
                if(userPost.Count != 0)
                {
                    _db.UserPosts.RemoveRange(userPost);
                    _db.SaveChanges();
                }
                if (post.Count != 0)
                {
                    _db.Posts.RemoveRange(post);
                    _db.SaveChanges();
                }
                if (usergroup.Count != 0)
                {
                    _db.UserGroups.RemoveRange(usergroup);
                    _db.SaveChanges();
                }
                if (follow.Count != 0)
                {
                    _db.Follows.RemoveRange(follow);
                    _db.SaveChanges();
                }
                if (comment.Count != 0)
                {
                    _db.Comments.RemoveRange(comment);
                    _db.SaveChanges();
                }
                if(userAccess.Count != 0)
                {
                    _db.UserAccessibilities.RemoveRange(userAccess);
                    _db.SaveChanges();
                }
                _db.Users.Remove(user);
                _db.SaveChanges();
            }


        }
        
        public bool Save(User user)
        {
            if (user.Id == 0)
            {
                if (!IsExisting(user))
                {
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void Update(User user)
        {
            var User = _db.Users.FirstOrDefault(p => p.Id == user.Id);
            if (User != null)
            {
                User.Address = user.Address;
                User.Age = user.Age;
                User.Email = user.Email;
                User.Image = user.Image;
                User.Name = user.Name;
                User.Password = user.Password;
                User.Paypal = user.Paypal;
                User.Phone = user.Phone;
                User.Study = user.Study;
                User.UserName = user.UserName;
                User.Description = user.Description;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(User user)
        {
            bool data = _db.Users.Any(p => p.Email == user.Email || p.UserName==user.UserName);
            if (data == false)
            {
                return false;
            }
            return true;
        }
        public bool ChangePassword(string email, string password)
        {
            var data = _db.Users.FirstOrDefault(p => p.Email == email);
            if (data != null)
            {
                data.Password = password;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public User SignIn(string email, string password)
        {
            var data = _db.Users.FirstOrDefault(p => p.Email == email);
            if(data != null && data.Password==password)
            {
                return data;  
            }
           else return null;
        }
    }
}
