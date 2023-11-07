using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwom1BAIS3150CodeSample.Domain;
using nekwom1BAIS3150CodeSample.TechnicalServices;

namespace nekwom1BAIS3150CodeSample.Pages
{
    public class EnrollStudentModel : PageModel
    {
        List<Program> ProgramList = new();
        [BindProperty]
        public string Message { get; set; } = string.Empty;
        [BindProperty]
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
        List<string> ErrorList { get; set; } = new List<string>();
        public void OnGet()
        {
            Message = "Add a Student";
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
            else if (ProgramCode ==null)
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
                try
                {
                    Students students = new Students();
                    students.AddStudent(Student, ProgramCode);
                }
                catch (Exception ex)
                {
                    ErrorList.Add(ex.Message);
                    Message = ex.Message;
                    Console.WriteLine(ex.Message);
                }

                Message = "The Student Has Been Enrolled";
            }
            else
            {
                Message = "Student Cant be Added Errors Found";

            }


        }
    }
}
