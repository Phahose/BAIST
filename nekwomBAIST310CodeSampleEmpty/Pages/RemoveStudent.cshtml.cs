using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwomBAIST310CodeSampleEmpty.TechnicalServices;
using nekwomBAIST310CodeSampleEmpty.Domain;
using System.ComponentModel.DataAnnotations;

namespace nekwomBAIST310CodeSampleEmpty.Pages
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
            BCS bCS = new BCS();
            bCS.RemoveStudent(StudentID);
            Message = "The student has been deleted";
        }
    }
}
