namespace GraduationProjectAPI.Model
{
    public class GameUser
    {
        public int Id { set; get; }
        public string userLevel { set; get; }
        public int Score { set; get; }
        public int IdGame { set; get; }
        public virtual Game? Game { set; get; }
        public int IdUser { set; get; }
        public virtual User? User { set; get; }
    }
}
