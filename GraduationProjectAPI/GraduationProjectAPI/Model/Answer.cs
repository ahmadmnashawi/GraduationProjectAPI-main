
namespace GraduationProjectAPI.Model
{
    public class Answer
    {
        public int Id { set; get; }
        public string answer { set; get; }
        public bool CorrectAnswer { set; get; }
        public int? IdTest { set; get; }
        public Test? Test { set; get; }
    }
}
