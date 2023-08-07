using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_School_Data_Design_Practice_Project
{
    public interface IClassSection
    {
        string Name { get; set; }
        List<IStudent> Students { get; }
        List<ITeacher> Teachers { get; }
    }
}
