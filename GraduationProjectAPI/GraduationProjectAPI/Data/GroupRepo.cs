using GraduationProjectAPI.Dto;
using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAPI.Data
{
    public class GroupRepo:IGroup
    {
        private readonly GraduationProjectDbContext _db;
        public GroupRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Group> GetGroups => _db.Groups;

        public void Delete(int id)
        {
            var group = _db.Groups.FirstOrDefault(p => p.Id == id);
            if (group != null)
            {
                var userGroup = _db.UserGroups.Where(p => p.IdGroup == group.Id).ToList();
                var post = _db.Posts.Where(p => p.IdGroup == group.Id).ToList();
                var useraccess = _db.UserAccessibilities.Where(p => p.IdGroup == group.Id).ToList();
                if(userGroup.Count != 0)
                {
                    _db.UserGroups.RemoveRange(userGroup);
                    _db.SaveChanges();
                }
                if (post.Count != 0)
                {
                    _db.Posts.RemoveRange(post);
                    _db.SaveChanges();
                }
                if (useraccess.Count != 0)
                {
                    _db.UserAccessibilities.RemoveRange(useraccess);
                    _db.SaveChanges();
                }
                _db.Groups.Remove(group);
                _db.SaveChanges();
            }
            //var group = _db.Groups.FirstOrDefault(p => p.Id == Group.Id);
            //if (group != null)
            //{
            //    group.IsDeleted = true;
            //    _db.SaveChanges();
            //}
        }
        public Group GetGroup(int id)
        {
            var group = _db.Groups.FirstOrDefault(p => p.Id == id);
            if (group != null)
                return group;
            else
                return null;

        }
        public bool Save(Group group)
        {
            if (group.Id == 0)
            {
                if ( !IsExiting(group.groupName))
                {
                    _db.Groups.Add(group);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void Update(Group group)
        {
            var Group = _db.Groups.First(p => p.Id == group.Id);
            if (Group != null)
            {
                Group.groupName = group.groupName;
                Group.Description = group.Description;
                Group.Image = group.Image;
                Group.IdContent = group.IdContent;
                //Group.IsDeleted = group.IsDeleted;
                _db.SaveChanges();
            }
        }
        public bool IsExiting (string GroupName)
        {
            var data = _db.Groups.Any(p => p.groupName.Equals(GroupName));
            // var data = _db.Contents.Where(u => string.Equals(u.typeName, content.typeName, StringComparison.CurrentCultureIgnoreCase));
            if (data == false)
            {
                return false;
            }
            else return true;
        }
        public List<User> GetGroupMembers(int IdGroup)
        {
            var data = _db.Groups.FirstOrDefault(p => p.Id == IdGroup);
            if (data != null)
            {
                List<User> users = new List<User>();
                List<UserGroup> userGroups = _db.UserGroups.Where(p => p.IdGroup == IdGroup).Include(p => p.User).ToList();
                foreach(UserGroup ug in userGroups)
                {
                    User user = _db.Users.FirstOrDefault(p => p.Id == ug.IdUser);
                    users.Add(user);
                }
                if (users.Count != 0) return users;
                else return null;
            }
            else return null;
            return null;
        }
        public List<PostDto> GroupPost(int IdGroup,int idUser)
        {
            Group data = _db.Groups.FirstOrDefault(p => p.Id == IdGroup);
            if (data != null)
            {
                List<Post> posts = _db.Posts.Where(p => p.IdGroup == IdGroup).ToList();
                List<PostDto> dto = new List<PostDto>();
                foreach(Post p in posts)
                {
                    UserPost us = _db.UserPosts.FirstOrDefault(e => e.IdUser == idUser && e.IdPost==p.Id);
                    PostDto postDto = new PostDto();
                    User u = _db.Users.FirstOrDefault(e => e.Id == p.IdUser);
                    if (us != null)
                    {
                        postDto.GroupImage = data.Image;
                        postDto.GroupName = data.groupName;
                        postDto.Interaction = us.Interaction;
                        postDto.NumberLike = NumberLikes(p.Id);
                        postDto.post = p;
                        postDto.UserImage = u.Image;
                        postDto.UserName = u.UserName;
                        dto.Add(postDto);
                    }
                    else
                    {
                        postDto.GroupImage = data.Image;
                        postDto.GroupName = data.groupName;
                        postDto.Interaction = false;
                        postDto.NumberLike = NumberLikes(p.Id);
                        postDto.post = p;
                        postDto.UserImage = u.Image;
                        postDto.UserName = u.UserName;
                        dto.Add(postDto);
                    }
                }
                return dto;
            }
            else return null;
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
        public bool ExisitInGroup(int IdUser,int IdGroup)
        {
            var user = _db.Users.FirstOrDefault(p => p.Id == IdUser);
            var group = _db.Groups.FirstOrDefault(p => p.Id == IdGroup);
            if(user != null && group != null)
            {
                UserGroup ug = _db.UserGroups.FirstOrDefault(p => p.IdUser == IdUser && p.IdGroup == IdGroup);
                if(ug!= null)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
