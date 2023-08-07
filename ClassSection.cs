using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_School_Data_Design_Practice_Project
{
    public class ClassSection : IClassSection
    {
        public string Name { get; set; }
        public List<IStudent> Students { get; } = new List<IStudent>();
        public List<ITeacher> Teachers { get; } = new List<ITeacher>();

    }
}
