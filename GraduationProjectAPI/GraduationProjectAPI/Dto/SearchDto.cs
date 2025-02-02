namespace GraduationProjectAPI.Dto
{
    public class SearchDto
    {
        public string Type { set; get; }
        public List<SubSearchDto> search { set; get; } 
    }
    public class SubSearchDto
    {
        public object SearchData { get; set; }
        public bool? IsFollowed { get; set; }

    }
}
