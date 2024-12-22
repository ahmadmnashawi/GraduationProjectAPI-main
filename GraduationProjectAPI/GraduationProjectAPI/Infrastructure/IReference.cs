using GraduationProjectAPI.Model;
using GraduationProjectAPI.Dto;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IReference
    {
        public Reference GetReference(int id);
        public IQueryable<Reference> GetReferences { get; }
        public bool Save(Reference reference);
        public void Update(Reference reference);
        public void Delete(Reference reference);
        public List<Content> GetRefrencesContent();
        public List<Reference> GetRefrenceLink(int IdContenet);
        public List<RefrenceDto> GetAllRefrencesAdmins();
        public List<string> GetRefrenceByAdmin(int IdUser);
    }
}
