using BlazorServerUIApp.Models.RequestModels.Student;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorServerUIApp.Components.Student
{
    public partial class AddUpdateStudentComponent
    {
        [Parameter]
        public int? StudentId { get; set; }

        private AddUpdateStudentReq request { get; set; } = new AddUpdateStudentReq();


        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private void OnSubmit()
        {

        }

        private async Task LoadPhoto(InputFileChangeEventArgs e)
        {
            var file = e.File;
            var buffer = new byte[file.Size];
            await file.OpenReadStream().ReadAsync(buffer);
            request.Photo = buffer;
        }
    }
}
