namespace GraduationProjectAPI.Model
{
    public class UserReference
    {
        public int Id { set; get; }
        public int IdUser { set; get; }
        public virtual User? User { set; get; }
        public int IdReference { set; get; }
        public virtual Reference? Reference { set; get; }
    }
}
