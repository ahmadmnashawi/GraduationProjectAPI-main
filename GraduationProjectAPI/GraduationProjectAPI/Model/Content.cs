namespace GraduationProjectAPI.Model
{
    public class Content
    {
       public int Id { set; get; }
       public string typeName { set; get; }
       public virtual ICollection<Post>? Post { set; get; }
       public virtual ICollection<Test>? Test { set; get; }
       public virtual ICollection<Group>? Group { set; get; }
       public virtual ICollection<Reference>? Reference { set; get; }
        
    }
}
