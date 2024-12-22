namespace GraduationProjectAPI.Model
{
    public class Follow
    {
        public int Id { set; get; }
        public int? followId { set; get; }
        public int? followedId { set; get; }
        public virtual User? follow { set; get; }
        public virtual User? followed { set; get; }
    }
}
