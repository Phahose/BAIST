using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwomBAIS3150CodeSampleEmpty.Domain;
using nekwomBAIS3150CodeSampleEmpty.TechnicalServices;

namespace nekwomBAIS3150CodeSampleEmpty.Pages
{
    public class ModifyStudentModel : PageModel
    {
   
        public string Message { get; set; } = string.Empty;
        public Student Student { get; set; } = new Student();
        [BindProperty]
        public string Id { get; set; } = string.Empty;
        [BindProperty]
        public string Firstname { get; set; } = string.Empty;
        [BindProperty]
        public string Lastname { get; set; } = string.Empty;
        [BindProperty]
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        public string ProgramCode { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Modify a Student";
        }

        public void OnPost()
        {
            if (Id == null)
            {
                ModelState.AddModelError("IdInput", "Id is Required");
            }
            else if (Firstname == null)
            {
                ModelState.AddModelError("FirstnameInput", "Firstname is Required");
            }
            else if (Lastname == null)
            {
                ModelState.AddModelError("LastnameInput", "Lastname is Required");
            }
            else if (Email == null)
            {
                ModelState.AddModelError("EmailInput", "Email is Required");
            }
            else if (Lastname == null)
            {
                ModelState.AddModelError("LastnameInput", "Lastname is Required");
            }
            else if (ProgramCode == null)
            {
                ModelState.AddModelError("ProgramCodeInput", "PrgramCode is Required");
            }
            else
            {
                Student.StudentId = Id;
                Student.FirstName = Firstname;
                Student.LastName = Lastname;
                Student.Email = Email;
            }

            if (ModelState.IsValid)
            {
                Students students = new();
                students.UpdateStudent(Student);

                Message = "The Student Has Been Updated";
            }
            else
            {
                Message = $"Student Cant be Modified Errors Found {ModelState.ValidationState}";

            }

        }
    }
}

