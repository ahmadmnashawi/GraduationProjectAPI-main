using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Dto
{
    public class CommentDto
    {
        public Comments comment { set; get; }
        public byte[] UserImage { set; get; }
        public string UserName { set; get; }
    }
}
