using GraduationProjectAPI.Dto;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IGroup
    {
        public Group GetGroup(int id);
        public IQueryable<Group> GetGroups { get; }
        public bool Save(Group group);
        public void Update(Group group);
        public void Delete(int id);
        public List<User> GetGroupMembers(int IdGroup);
        public List<PostDto> GroupPost(int IdGroup,int IdUser);
        public bool ExisitInGroup(int IdUser,int IdGroup);
    }
}
