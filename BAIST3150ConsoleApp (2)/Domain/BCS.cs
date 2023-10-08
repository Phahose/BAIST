using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BAIST3150ConsoleApp.Techenical_Services;

namespace BAIST3150ConsoleApp.Domain
{
    internal class BCS
    {
        public bool EnrollStudent(Student acceptedStudents, string programcode)
        {
            bool Confirmation;
            Students StudentManager = new();

            Confirmation = StudentManager.AddStudent(acceptedStudents, programcode);
            return Confirmation;
        }

       
    }
}
