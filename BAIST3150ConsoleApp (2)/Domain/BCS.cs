using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAIS3150ConsoleApp;
using BAIST3150ConsoleApp.Techenical_Services;
using Microsoft.Data.SqlClient;

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
        public Student FindStudent(string studentID)
        {
            Student EnrolledStudent = new();
            Students StudentManager = new();

            EnrolledStudent = StudentManager.GetStudent(studentID);
            return EnrolledStudent;
        }


        public bool ModifyStudent(Student EnrolledStudent)
        {
            bool confirmation = false;
            Students StudentManager = new();

            confirmation = StudentManager.UpdateStudent(EnrolledStudent);
            confirmation = true;
            return confirmation;
        }

       public bool RemoveStudent(string studentId)
       {
            bool confirmation = false;
            Students StudentManager = new();

            confirmation = StudentManager.DeleteStudent(studentId);
            confirmation = true;
            return confirmation;
       }

        public Program FindProgram(string ProgramCode)
        {
            Program ActiveProgram;            
            Programs ProgramManager = new();
            ActiveProgram = ProgramManager.GetProgram(ProgramCode);
            return ActiveProgram;
        }
    }
}
