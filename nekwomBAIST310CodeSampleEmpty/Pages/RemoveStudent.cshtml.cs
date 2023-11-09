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
        [BindProperty]
        public string Submit { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Delete a Student Enter The ID";
        }

        public void OnPost()
        {
            BCS bCS = new BCS();
            switch (Submit)
            {
                case "Getstudents":
                    if (StudentID == null)
                    {
                        ModelState.AddModelError("IdInput", "Id is Required");
                        Message = $"Student Cant be Gotten Errors Found {ModelState.ValidationState}";
                    }
                    else
                    {
                        Student = bCS.FindStudent(StudentID);
                    }

                    break;
                case "DeleteStudent":
                    if (StudentID != null)
                    {
                        Students students = new();

                        bCS.RemoveStudent(StudentID);
                        Message = "The student has been deleted";
                    }
                    else
                    {
                        Message = "The Student cannnot Be added Errprs Found";
                    }
                break;
            }
           
        }
    }
}
