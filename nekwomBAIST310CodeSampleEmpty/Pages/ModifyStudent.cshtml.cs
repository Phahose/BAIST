using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nekwomBAIST310CodeSampleEmpty.Domain;
using nekwomBAIST310CodeSampleEmpty.TechnicalServices;

namespace nekwomBAIST310CodeSampleEmpty.Pages
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
        [BindProperty]
        public string Submit {  get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Modify a Student";
        }

        public void OnPost()
        {
            BCS bCS = new BCS();
            switch (Submit)
            {
                case "Getstudents":
                    if (Id == null)
                    {
                        ModelState.AddModelError("IdInput", "Id is Required");
                        Message = $"Student Cant be Gotten Errors Found {ModelState.ValidationState}";
                    }
                    else
                    {
                        Student = bCS.FindStudent(Id);
                    }
                        
                break;

                case "ModifyStudent":
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
                        bCS.ModifyStudent(Student);
                        Message = "The Student Has Been Updated";
                    }
                    else
                    {
                        Message = $"Student Cant be Modified Errors Found {ModelState.ValidationState}";

                    }
                   
                    break;
            }
            

        }
    }
}

