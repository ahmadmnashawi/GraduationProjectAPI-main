using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAPI.Model
{
    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string  Age { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public byte[]? Image { set; get; }
        public string? Study { set; get; }
        public string? Address { set; get; }
        public string? Paypal { set; get; }
        public string Email { set; get; }
        public string? Phone { set; get; }
        public string? Description { set; get; }
        public virtual ICollection<UserReference>? UserReference { set; get; }
        public virtual ICollection<Complaint>? Complaint { set; get; }
        public virtual ICollection<GameUser>? GameUser { set; get; }
        public virtual ICollection<Buybook>? Buybook { set; get; }
        public virtual ICollection<UserPost>? UserPost { set; get; }
        public virtual ICollection<Post>? Post { set; get; }
      //  public virtual ICollection<Group>? Group { set; get; }
        public virtual ICollection<Follow>? follow { set; get; }
        public virtual ICollection<Follow>? followed { set; get; }
        public virtual ICollection<Comments>? Comment { set; get; }
        public virtual ICollection<UserGroup>? UserGroup { set; get; }
        public virtual ICollection<UserAccessibility>? UserAccessibility { set; get; }
    }
}
