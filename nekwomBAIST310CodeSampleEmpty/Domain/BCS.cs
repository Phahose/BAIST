using nekwomBAIST310CodeSampleEmpty.Domain;
using nekwomBAIST310CodeSampleEmpty.TechnicalServices;

namespace nekwomBAIST310CodeSampleEmpty.Domain
{
    public class BCS
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


        public bool ModifyStudent(Domain.Student EnrolledStudent)
        {
            bool confirmation;
            Students StudentManager = new();

            confirmation = StudentManager.UpdateStudent(EnrolledStudent);
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

        public Domain.Program FindProgram(string ProgramCode)
        {
            Domain.Program ActiveProgram;
            TechnicalServices.Programs ProgramManager = new();
            ActiveProgram = ProgramManager.GetProgram(ProgramCode);
            return ActiveProgram;
        }



        public bool CreateProgram(string programCode, string description)
        {
            bool confirmation;

            TechnicalServices.Programs programs = new();
            confirmation = programs.AddProgram(programCode, description);
            return confirmation;
        }

        public DatabserUser FindDatabaseuser()
        {
            DatabaseUsers databaseUsers = new ();
            DatabserUser databaseUser = databaseUsers.GetDatabaseUser();

            return databaseUser;
        }
    }
}
