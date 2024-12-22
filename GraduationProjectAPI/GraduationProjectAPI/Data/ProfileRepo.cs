using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAPI.Data
{
    public class ProfileRepo :IProfile
    {
        public readonly GraduationProjectDbContext _db;
        public List<PostDto> dto = new List<PostDto>();
        public ProfileRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public List<User> UserFollow(int IdUser)
        {
            var user = _db.Users.Where(p => p.Id == IdUser);
            if(user != null)
            {
                List<User> users = new List<User>();
                List<Follow> follows = _db.Follows.Where(p => p.followId == IdUser).Include(p=>p.follow).Include(p => p.followed).ToList();
                foreach(Follow f in follows)
                {
                    User u = f.followed;
                    users.Add(u);
                }
                return users;
            }
           else return null;
        }
        public List<User> FollowUser(int IdUser)
        {
            var user = _db.Users.Where(p => p.Id == IdUser);
            if (user != null)
            {
                List<User> users = new List<User>();
                List<Follow> follows = _db.Follows.Where(p => p.followedId == IdUser).Include(p => p.followed).Include(p => p.follow).ToList();
                if (follows.Count == 0) return null;
                foreach (Follow f in follows)
                {
                    // User u = _db.Users.FirstOrDefault(p => p.Id == f.followId);
                    User u = f.follow;
                    users.Add(u);
                }
                return users;

            }
            else return null;
        }
        public List<Group> UserGroups(int IdUser)
        {
            var user = _db.Users.Where(p => p.Id == IdUser);
            if (user != null)
            {
                List<Group> groups = new List<Group>();
                List<UserGroup> userGroup = _db.UserGroups.Where(p => p.IdUser == IdUser).ToList();
                foreach(UserGroup ug in userGroup)
                {
                    Group data = _db.Groups.FirstOrDefault(p => p.Id == ug.IdGroup);
                    groups.Add(data);
                }
                if (groups.Count == 0) return null;
                return groups;
            }
            else return null;
        }
        public List<PostDto> UserPosts(int IdUser)
        {
            User user = _db.Users.FirstOrDefault(p => p.Id == IdUser);
            if (user != null)
            {
           
                List<Post> posts = _db.Posts.Where(p => p.IdUser == IdUser).ToList();
               // List<Group> groups = _db.Groups.Where(p => p.IdUser == IdUser).Include(p=>p.Post.Where(e=>e.IdUser==IdUser)).ToList();
                if(posts.Count != 0)
                {
                    
                    foreach(Post p in posts)
                    {
                        UserPost up = _db.UserPosts.Where(p => p.IdPost == p.Id && p.IdUser == IdUser).FirstOrDefault();
                        PostDto postDto = new PostDto();
                        if (up != null)
                        {
                            if (p.IdGroup == 0)
                            {
                                postDto.UserName = user.UserName;
                                postDto.UserImage = user.Image;
                                postDto.GroupName = null;
                                postDto.GroupImage = null;
                                postDto.Interaction = up.Interaction;
                                postDto.NumberLike = NumberLikes(p.Id);
                                postDto.post = p;
                                dto.Add(postDto);
                            }
                            else
                            {
                                Group group = _db.Groups.FirstOrDefault(g => g.Id == p.IdGroup);
                                postDto.UserName = user.UserName;
                                postDto.UserImage = user.Image;
                                postDto.GroupName = group.groupName;
                                postDto.GroupImage = group.Image;
                                postDto.Interaction = up.Interaction;
                                postDto.NumberLike = NumberLikes(p.Id);
                                postDto.post = p;
                                dto.Add(postDto);
                            }
                        }
                        else
                        {
                            if (p.IdGroup == null || p.IdGroup==0)
                            {
                                postDto.UserName = user.UserName;
                                postDto.UserImage = user.Image;
                                postDto.GroupName = null;
                                postDto.GroupImage = null;
                                postDto.Interaction = false;
                                postDto.NumberLike = NumberLikes(p.Id);
                                postDto.post = p;
                                dto.Add(postDto);
                            }
                            else
                            {
                                Group group = _db.Groups.FirstOrDefault(g => g.Id == p.IdGroup);
                                postDto.UserName = user.UserName;
                                postDto.UserImage = user.Image;
                                postDto.GroupName = group.groupName;
                                postDto.GroupImage = group.Image;
                                postDto.Interaction = false;
                                postDto.NumberLike = NumberLikes(p.Id);
                                postDto.post = p;
                                dto.Add(postDto);
                            }
                        }
                    }
                }
                //if(groups.Count != 0)
                //{
                //    foreach(Group g in groups)
                //    {
                //        PostDto postDto = new PostDto();
                //        // List<Post> groupPost = _db.Posts.Where(p => p.IdGroup == g.Id && p.IdUser == IdUser).ToList();
                //        UserGroupPost(IdUser, g);
                //    }
                //}
                if (dto.Count != 0) return dto;
                else return null;
            }
            else return null;
        }
        public void UserGroupPost(int IdUser,Group g)
        {
            List<Post> groupPost = _db.Posts.Where(p => p.IdGroup == g.Id && p.IdUser == IdUser).ToList();
            foreach(Post p in groupPost)
            {
                User u = _db.Users.FirstOrDefault(p => p.Id == IdUser);
                PostDto postDto = new PostDto();
                postDto.UserName =u.UserName;
                postDto.UserImage = u.Image;
                postDto.GroupName = g.groupName;
                postDto.GroupImage = g.Image;
                postDto.Interaction = _db.UserPosts.FirstOrDefault(n => n.IdUser == IdUser && n.IdPost == p.Id).Interaction;
                postDto.NumberLike = NumberLikes(p.Id);
                postDto.post = p;
                dto.Add(postDto);
            }
        }
        public double NumberLikes(int IdPost)
        {
            double likes = _db.UserPosts.Where(p => p.IdPost == IdPost).Count();
            if (likes != 0)
            {
                return likes;
            }
            return 0;
        }
        public User GetUser(int id)
        {
            var user = _db.Users.FirstOrDefault(p => p.Id == id);
            if (user != null)
                return user;
            else
                return null;

        }
    }
}
