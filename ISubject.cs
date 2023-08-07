using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_School_Data_Design_Practice_Project
{
    public interface ISubject
    {
        string Name { get; set; }
        string SubjectCode { get; set; }
        ITeacher Teacher { get; set; }
    }
}
