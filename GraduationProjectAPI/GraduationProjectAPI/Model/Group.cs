namespace GraduationProjectAPI.Model
{
    public class Group
    {
        public int Id { set; get; }
        public string groupName { set; get; }
        public string? Description  { set; get; }
        public int IdContent { set; get; }
        public virtual Content? Content { set; get; }
        public byte[]? Image { set; get; }
        public virtual ICollection<Post>? Post { set; get; }
        public virtual ICollection<UserGroup>? UserGroup { set; get; }
        public virtual ICollection<UserAccessibility>? UserAccessibility { set; get; }
        //image
    }
}
