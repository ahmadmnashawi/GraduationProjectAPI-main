namespace GraduationProjectAPI.Model
{
    public class UserPost
    {
        public int Id { set; get; }
        public bool Interaction { set; get; }
        public int IdUser { set; get; }
        public virtual User? User { set; get; }
        public int IdPost { set; get; }
        public virtual Post? Post { set; get; }
    }
}
