using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Dto;
using GraduationProjectAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAPI.Data
{
    public class MainRepo :IMain
    {
        public readonly GraduationProjectDbContext _db;
        List<UserGroup> Usergroups = new List<UserGroup>();
        List<Group> group = new List<Group>();
        List<Follow> users = new List<Follow>();
      //  List<Comment> posts = new List<Comment>();
        List<Post> posts = new List<Post>();
        List<PostDto> postDtos = new List<PostDto>();
        int  idUser = 0;
        public MainRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public List<PostDto> Posts (int id)
        {
            User user = _db.Users.FirstOrDefault(p => p.Id == id);
            if(user != null)
            {
                idUser = user.Id;
                // groups = _db.Groups.Where(p => p.IdUser == id).ToList();
              Usergroups = _db.UserGroups.Where(p => p.IdUser == id).Include(p => p.Group).ToList();
                users = _db.Follows.Where(p => p.followId == id).ToList();
              if(Usergroups.Count != 0)
              {
                 GetGroupsPost();
                 
              }
              if(users.Count != 0)
              {
                    GetUsersPost();
              }
              if (posts.Count != 0)
                {
                    PostsUser();
                }
              if (postDtos.Count != 0)
                {
                    return postDtos;
                }
              else return null;
            }
            return null;
        }
        public void GetGroupsPost()
        {
           foreach(UserGroup g in Usergroups)
           {
                //    var groupPost = _db.Posts.Where(p => p.IdGroup == g.Id).SelectMany(t=>t.Comment).Include(r=>r.Post).ToList();
                var groupPost = _db.Posts.Where(p => p.IdGroup == g.IdGroup && p.IdUser != idUser).Include(R=>R.Comment).Include(r => r.Group).ToList();
                posts.AddRange(groupPost);
            }
           
        }
        public void GetGroupsContentPost(List<Group> groups)
        {
            foreach (Group g in groups)
            {
                //    var groupPost = _db.Posts.Where(p => p.IdGroup == g.Id).SelectMany(t=>t.Comment).Include(r=>r.Post).ToList();
                var groupPost = _db.Posts.Where(p => p.IdGroup == g.Id && p.IdUser != idUser).Include(R => R.Comment).Include(r => r.Group).ToList();
               
                    posts.AddRange(groupPost);
     
            }

        }
        public void GetUsersPost()
        {
           foreach(Follow f in users)
            {
                // var userPost = _db.Users.Where(p => p.Id == f.followedId).SelectMany(p => p.Post.SelectMany(t=>t.Comment)).ToList();
                //  var data = _db.Posts.Where(p => p.IdUser == f.followedId).SelectMany(p => p.Comment).Include(r => r.Post).ToList();
                var data = _db.Posts.Where(p => p.IdUser == f.followedId && p.IdGroup==0).Include(r => r.Comment).ToList();
                posts.AddRange(data);
            }
         
        }
        public List<PostDto> PostsUser()
        {
            foreach (Post e in posts)
            {
              //  var user = _db.Users.Where(p => p.Id == idUser);
                //var interaction = _db.UserPosts.Where(p => p.IdUser == idUser && p.IdPost==e.IdPost);
                if(e.IdGroup == 0 || e.IdGroup ==null )
               {
                    PostDto dto = new PostDto();
                    UserPost interaction = _db.UserPosts.Where(p=> p.IdPost == e.Id && p.IdUser==idUser).Include(r => r.Post).Include(r => r.User).FirstOrDefault();
                    User us = _db.Users.FirstOrDefault(p => p.Id == e.IdUser);
                    if (interaction != null)
                    {
                        dto.post = e;
                        // dto.Image = e.Post.User.Image;
                        dto.UserImage =us.Image;
                        dto.Interaction = interaction.Interaction;
                       // dto.Name = e.Post.User.Name;
                        dto.UserName = us.UserName;
                        dto.NumberLike = NumberLikes(e.Id);
                        dto.GroupName = null;
                        dto.GroupImage = null;
                      //  dto.comments = _db.Comments.Where(p => p.IdPost == e.Id).ToList();
                        postDtos.Add(dto);
                    }
                    else
                    {
                        
                        dto.post = e;
                        //     dto.Image = e.Post.User.Image;
                        dto.UserImage = us.Image;
                        dto.Interaction = false;
                        // dto.Name = e.Post.User.Name;
                        dto.UserName = us.UserName;
                        dto.NumberLike = NumberLikes(e.Id);
                        dto.GroupName = null;
                        dto.GroupImage = null;
                       // dto.comments = _db.Comments.Where(p => p.IdPost == e.Id).ToList();
                        postDtos.Add(dto);
                    }
                }
                else if(e.IdGroup != 0 )
                {

                    PostDto dto = new PostDto();
                    Group group = _db.Groups.FirstOrDefault(p => p.Id == e.IdGroup);
                    User us = _db.Users.FirstOrDefault(p => p.Id == e.IdUser);
                    UserPost interaction = _db.UserPosts.Where(p => p.IdPost == e.Id && p.IdUser==idUser).Include(r => r.Post).Include(r => r.User).FirstOrDefault();
                    if (interaction != null)
                    {
                        dto.post = e;
                        // dto.Image = e.Post.User.Image;
                        dto.UserImage = us.Image;
                        dto.Interaction = interaction.Interaction;
                        // dto.Name = e.Post.User.Name;
                        dto.UserName = us.UserName;
                        dto.NumberLike = NumberLikes(e.Id);
                        dto.GroupName = group.groupName;
                        dto.GroupImage = group.Image;
                       // dto.comments = _db.Comments.Where(p => p.IdPost == e.Id).ToList();
                        postDtos.Add(dto);
                    }
                    else
                    {
                        dto.post = e;
                        //     dto.Image = e.Post.User.Image;
                        dto.UserImage = us.Image;
                        dto.Interaction = false;
                        // dto.Name = e.Post.User.Name;
                        dto.UserName = us.UserName;
                        dto.NumberLike = NumberLikes(e.Id);
                        dto.GroupName = group.groupName;
                        dto.GroupImage = group.Image;
                      //  dto.comments = _db.Comments.Where(p => p.IdPost == e.Id).ToList();
                        postDtos.Add(dto);

                    }
                }
            }
            if (postDtos.Count != 0) return postDtos;
            else return null;
        }
        public List<PostDto> PostContent(int IdUser, int IdContent)
         {
            var content = _db.Contents.Where(p => p.Id == IdContent);
            User user = _db.Users.FirstOrDefault(p => p.Id == IdUser);
            if (content != null && user != null)
            {
                idUser = user.Id;
                List<UserGroup> userGroup = _db.UserGroups.Where(p => p.IdUser == idUser).ToList();
                foreach(UserGroup ug in userGroup)
                {
                Group  data = _db.Groups.Where(p => p.Id == ug.IdGroup && p.IdContent == IdContent).FirstOrDefault();
                    if(data != null)
                    group.Add(data);
                }       
                users = _db.Follows.Where(p => p.followId == IdUser).ToList();
                if (group.Count != 0)
                {
                    GetGroupsContentPost(group);

                }
                if (users.Count != 0)
                {
                    GetUserPostContent(IdContent);
                }
                if (posts.Count != 0)
                {
                    PostsUser();
                }
                if (postDtos.Count != 0)
                {
                    return postDtos;
                }
                else return null;
            }
            else
            {
                return null;
            }
        }
        public void GetUserPostContent(int IdContent)
        {
            foreach (Follow f in users)
            {
                var data = _db.Posts.Where(p => p.IdUser == f.followedId && p.IdContent == IdContent &&p.IdGroup==0).Include(r => r.Comment).ToList();
                posts.AddRange(data);
            }
        }
        public double NumberLikes(int IdPost)
        {
            double likes = _db.UserPosts.Where(p => p.IdPost == IdPost).Count();
            if(likes !=  0)
            {
                return likes;
            }
            return 0;
        }
    }
}
