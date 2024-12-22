using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
namespace GraduationProjectAPI.Data
{
    public class AnswerRepo :IAnswer
    {
        private readonly GraduationProjectDbContext _db;
        public AnswerRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Answer> GetAnswers => _db.Answers;

        public void Delete(Answer Answer)
        {
            var answer = _db.Answers.FirstOrDefault(p => p.Id == Answer.Id);
            if (answer != null)
            {
                _db.Answers.Remove(answer);
                _db.SaveChanges();
            }


        }
        public Answer GetAnswer(int id)
        {
            var answer = _db.Answers.First(p => p.Id == id);
            if (answer != null)
                return answer;
            else
                return null;

        }
        public void Save(Answer answer)
        {
            if (answer.Id == 0)
            {
                
                    _db.Answers.Add(answer);
                    _db.SaveChanges();
                
            }

        }
        public void Update(Answer answer)
        {
            var Answer = _db.Answers.First(p => p.Id == answer.Id);
            if (Answer != null)
            {
                Answer.answer = answer.answer;
                Answer.CorrectAnswer = answer.CorrectAnswer;
                _db.SaveChanges();
            }
        }
        
    }
}

