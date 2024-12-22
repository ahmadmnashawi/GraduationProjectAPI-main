namespace GraduationProjectAPI.Model
{
    public class Post
    {
        public int Id { set; get; }
        public string Description { set; get; }
        public byte[]? Image { set; get; }
        public DateTime? dateTime { set; get; }
        public int IdUser { set; get; }
        public virtual User? User { set; get; }
        public int? IdContent { set; get; }
        public virtual Content? Content { set; get; }
        public int? IdGroup { set; get; }
        public virtual Group? Group { set; get; }
        public virtual ICollection<Comments>? Comment { set; get; }
    }
}
