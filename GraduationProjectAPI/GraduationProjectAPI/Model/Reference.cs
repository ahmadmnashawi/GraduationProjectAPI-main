namespace GraduationProjectAPI.Model
{
    public class Reference
    {
        public int Id { set; get; }
        public string referenceName { set; get; }
        public string Link { set; get; }
        public int IdContent { set; get; }
        public virtual Content? Content { set; get; }
        public virtual ICollection<UserReference>? UserReference { set; get; }
        public virtual ICollection<UserAccessibility>? UserAccessibility { set; get; }
    }
}
