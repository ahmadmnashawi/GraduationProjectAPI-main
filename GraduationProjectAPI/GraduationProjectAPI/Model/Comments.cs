namespace GraduationProjectAPI.Model
{
    public class Comments
    {
        public int Id { set; get; }
        public string Comment { set; get; }
        public int IdPost { set; get; }
        public  Post? Post { set; get; }
        public int IdUser { set; get; }
        public  User? User { set; get; }
    }
}
