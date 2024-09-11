using BlazorServerUIApp.Models.ResponseModels.Student;

namespace BlazorServerUIApp.Components.Student
{
    public partial class StudentListComponent
    {
        private List<StudentListingResp> Students = new List<StudentListingResp>
        {
            //new StudentListingResp { StudentId = 1, RollNo = "A001", FullName = "John Doe", Class = "10", Section = "A" },
            //new StudentListingResp { StudentId = 2, RollNo = "A002", FullName = "Jane Smith", Class = "10", Section = "B" },
        };
        private string searchText = string.Empty;


        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private void EditStudent(int studentId)
        {
            // Logic to edit student
        }

        private void DeleteStudent(int studentId)
        {
            // Logic to delete student
        }

        private void OnClick_Add()
        {
            _navigationManager.NavigateTo("add-student");
        }
    }
}
