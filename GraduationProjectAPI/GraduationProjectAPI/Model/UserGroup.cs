namespace GraduationProjectAPI.Model
{
    public class UserGroup
    {
        public int Id { set; get; }
        public int? IdGroup { set; get; }
        public virtual Group? Group { set; get; }
        public int? IdUser { set; get; }
        public virtual User? User { set; get; }
        
    }
}
