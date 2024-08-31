using BlazorServerUIApp.Models.ResponseModels.Student;

namespace BlazorServerUIApp.Components.Student
{
    public partial class StudentListComponent
    {
        private List<StudentListingResp> Students = new List<StudentListingResp>
        {
            new StudentListingResp { StudentId = 1, RollNo = "A001", FullName = "John Doe", Class = "10", Section = "A" },
            new StudentListingResp { StudentId = 2, RollNo = "A002", FullName = "Jane Smith", Class = "10", Section = "B" },
        };

        private StudentListingResp? selectedStudent;
        private bool isModalOpen = false;


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

        private void ViewDetails(int studentId)
        {
            selectedStudent = Students.Where(x => x.StudentId == studentId).FirstOrDefault();
            isModalOpen = true;
            // Logic to view student details
        }

        private void CloseModal()
        {
            isModalOpen = false;
        }
    }
}
