namespace GraduationProjectAPI.Model
{
    public class Accessibility
    {
        public int Id { set; get; }
        public string AccessibilityType { set; get; }
        public virtual ICollection<UserAccessibility>? UserAccessibility { set; get; }
    }
}
