namespace BlazorServerUIApp.Models.ResponseModels.Student
{
    public class StudentListingResp
    {
        public int StudentId { get; set; }

        public string RollNo { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Class { get; set; } = string.Empty;

        public string Section { get; set; } = string.Empty;
    }
}
