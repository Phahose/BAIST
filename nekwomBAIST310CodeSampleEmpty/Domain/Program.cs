namespace nekwomBAIST310CodeSampleEmpty.Domain
{
    public class Program
    {
        private string _programCode = "";
        private string _description = "";
        private List<Student> _enrolledStudents = new List<Student>();

        public string ProgramCode
        {
            get { return _programCode; }
            set { _programCode = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public List<Student> EnrolledStudents
        {
            get
            {
                return _enrolledStudents;
            }
        }

        public Program()
        {

        }
    }
}
