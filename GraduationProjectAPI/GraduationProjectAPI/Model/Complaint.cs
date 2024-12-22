 namespace GraduationProjectAPI.Model
{
    public class Complaint
    {
        public int Id { set; get; }
        public string complaint { set; get; }
        public int type { set; get; }
        public int IdUser { set; get; }
        public virtual User? User { set; get; }

    }
}
