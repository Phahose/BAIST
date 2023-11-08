using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwomBAIST310CodeSampleEmpty.Domain;
using nekwomBAIST310CodeSampleEmpty.TechnicalServices;
using System.ComponentModel.DataAnnotations;

namespace nekwomBAIST310CodeSampleEmpty.Pages
{
    public class FindStudentModel : PageModel
    {
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage ="Must Enter a Student Id")]
        public string StudentID { get; set; } = string.Empty;
        public nekwomBAIST310CodeSampleEmpty.Domain.Student Student { get; set; } = new();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            BCS bCS = new BCS();
            Student = bCS.FindStudent(StudentID);
        }
    }
}
