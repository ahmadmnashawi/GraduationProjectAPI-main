namespace GraduationProjectAPI.Model
{
    public class Comments
    {
        public int Id { set; get; }
        public string comment { set; get; }
        public int IdPost { set; get; }
        public virtual Post? Post { set; get; }
        public int IdUser { set; get; }
        public virtual User? User { set; get; }
    }
}
