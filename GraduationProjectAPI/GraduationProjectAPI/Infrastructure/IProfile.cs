using GraduationProjectAPI.Model;
using GraduationProjectAPI.Dto;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IProfile
    {
        public List<User> UserFollow(int IdUser);
        public List<User> FollowUser(int IdUser);
        public List<Group> UserGroups(int IdUser);
        public List<PostDto> UserPosts(int IdUser);
        public User GetUser(int id);
    }
}
