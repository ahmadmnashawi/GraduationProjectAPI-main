namespace GraduationProjectAPI.Model
{
    public class Game
    {
        public int Id { set; get; }
        public string GameName { set; get; }
        public string? GameLevel { set; get; }
        public byte[]? Image { set; get; }
        public virtual ICollection<GameUser>? GameUser { set; get; }
    }
}
