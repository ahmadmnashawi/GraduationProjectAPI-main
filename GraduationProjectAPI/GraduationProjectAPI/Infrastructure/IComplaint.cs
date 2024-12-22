using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IComplaint
    {
        public Complaint GetComplaint(int id);
        public List<Complaint> GetComplaints { get; }
        public void Save(Complaint complaint);
        public void Update(Complaint complaint);
        public void Delete(int Id);
        public List<Complaint> UserComplaint(int IdUser);
    }
}
