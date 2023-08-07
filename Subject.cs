using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_School_Data_Design_Practice_Project
{
    public class Subject : ISubject
    {
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public ITeacher Teacher { get; set; }
    }
}
