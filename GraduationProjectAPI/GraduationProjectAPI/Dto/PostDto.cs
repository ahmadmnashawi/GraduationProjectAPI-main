using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Dto
{
    public class PostDto
    {
        public Post post { set; get; }
        public bool Interaction { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public double NumberLike { get; set; }
       //public List<Comment> comments { set; get; }
        public byte[]? UserImage { set; get; }
        public byte[]? GroupImage { set; get; }
    }
}
