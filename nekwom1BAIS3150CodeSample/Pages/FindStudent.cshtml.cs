using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwom1BAIS3150CodeSample.Domain;
using nekwom1BAIS3150CodeSample.TechnicalServices;
using System.ComponentModel.DataAnnotations;

namespace nekwom1BAIS3150CodeSample.Pages
{
    public class FindStudentModel : PageModel
    {
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage ="Must Enter a Student Id")]
        public string StudentID { get; set; } = string.Empty;
        public Domain.Student Student { get; set; } = new();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Students students = new();
            Student = students.GetStudent(StudentID);
        }
    }
}
