using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_School_Data_Design_Practice_Project
{
    public class SubjectObserver : ITeacherObserver
    {
        private readonly ITeacher _teacher;

        public SubjectObserver(ITeacher teacher)
        {
            _teacher = teacher;
        }

        public void Update(ISubject subject)
        {
            Console.WriteLine($"{_teacher.Name} is now teaching {subject.Name} ({subject.SubjectCode})");
        }
    }

}
