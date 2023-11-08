using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwomBAIS3150CodeSampleEmpty.TechnicalServices;
using System.ComponentModel.DataAnnotations;

namespace nekwomBAIS3150CodeSampleEmpty.Pages
{
    public class RemoveStudentModel : PageModel
    {
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Must Enter a Student Id")]
        public string StudentID { get; set; } = string.Empty;
        public Domain.Student Student { get; set; } = new();
        public void OnGet()
        {
            Message = "Delete a Student Enter The ID";
        }

        public void OnPost()
        {
            Students students = new();
            students.DeleteStudent(StudentID);
            Message = "The student has been deleted";
        }
    }
}
