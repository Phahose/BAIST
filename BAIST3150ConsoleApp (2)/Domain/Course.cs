using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAIST3150ConsoleApp.Domain
{
    internal class Course
    {
        private string _id;
        private string _description;
        public Student _enrolledStudents;

        public string Id
        {
            get { return _id; } 
            set { _id = value; } 
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Student Student
        {
            get { return _enrolledStudents; }
            set { _enrolledStudents = value;}
        }

        public Course()
        {

        }
    }
}
