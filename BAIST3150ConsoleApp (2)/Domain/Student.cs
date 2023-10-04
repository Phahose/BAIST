using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAIST3150ConsoleApp.Domain
{
    internal class Student
    {
        private string _studentId = string.Empty;
        private string _firstName = string.Empty;
        private string _email = string.Empty;

        public string StudentId
        {
            get
            {
                return _studentId;
            }
            set
            {
                _studentId = value;
            }
        }
        public string FirstName
        {
           get => _firstName; // This is another way to write the line above 
           set => _firstName = value; // This way of writing can only take one statement but the other one can take more than one statement
        }
        public string LastName { get; set; } = string.Empty; // This is Auto implementation, no logic can be added to this when this method is done there is no need to be creating a private _lastName
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public Student()
        {
            // constructor logic
        }
    }
}
