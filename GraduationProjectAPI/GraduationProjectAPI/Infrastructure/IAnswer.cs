using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IAnswer
    {
        public Answer GetAnswer(int id);
        public IQueryable<Answer> GetAnswers { get; }
        public void Save(Answer answer);
        public void Update(Answer answer);
        public void Delete(Answer answer);
    }
}
