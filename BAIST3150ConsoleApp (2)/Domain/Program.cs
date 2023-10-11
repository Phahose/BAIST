using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAIST3150ConsoleApp.Domain
{
    internal class Program
    {
        private string _id ="";
        private string _description="";
        private readonly Student[] _enrolledStudents =Array.Empty<Student>();

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
            get { return _enrolledStudents[0]; }
        }

        public Program()
        {

        }
    }
}
