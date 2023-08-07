using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_School_Data_Design_Practice_Project
{
    public class Program
    {
        static void Main()
        {
            var dataStorage = SchoolDataStorage.GetInstance();

            while (true)
            {
                Console.WriteLine("\n--- School Data Management System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Teacher");
                Console.WriteLine("3. Add Subject");
                Console.WriteLine("4. Add Student to Class Section");
                Console.WriteLine("5. Add Teacher to Class Section");
                Console.WriteLine("6. Display Students in Class Section");
                Console.WriteLine("7. Display Subjects Taught by Teacher");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(dataStorage);
                        break;
                    case "2":
                        AddTeacher(dataStorage);
                        break;
                    case "3":
                        AddSubject(dataStorage);
                        break;
                    case "4":
                        AddStudentToClassSection(dataStorage);
                        break;
                    case "5":
                        AddTeacherToClassSection(dataStorage);
                        break;
                    case "6":
                        DisplayStudentsInClassSection(dataStorage);
                        break;
                    case "7":
                        DisplaySubjectsTaughtByTeacher(dataStorage);
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddStudent(SchoolDataStorage dataStorage)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter class and section: ");
            string classAndSection = Console.ReadLine();

            var student = new Student { Name = name, ClassAndSection = classAndSection };
            dataStorage.AddStudent(student);
            Console.WriteLine("Student added successfully!");
        }

        static void AddTeacher(SchoolDataStorage dataStorage)
        {
            Console.Write("Enter teacher name: ");
            string name = Console.ReadLine();
            Console.Write("Enter class and section: ");
            string classAndSection = Console.ReadLine();

            var teacher = new Teacher { Name = name, ClassAndSection = classAndSection };
            dataStorage.AddTeacher(teacher);
            Console.WriteLine("Teacher added successfully!");
        }

        static void AddSubject(SchoolDataStorage dataStorage)
        {
            Console.Write("Enter subject name: ");
            string name = Console.ReadLine();
            Console.Write("Enter subject code: ");
            string subjectCode = Console.ReadLine();
            Console.Write("Enter the teacher's class and section: ");
            string teacherClassAndSection = Console.ReadLine();

            var teacher = dataStorage.GetTeachers().FirstOrDefault(t => t.ClassAndSection == teacherClassAndSection);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found for the given class and section. Please add the teacher first.");
                return;
            }

            var subject = new Subject { Name = name, SubjectCode = subjectCode, Teacher = teacher };
            dataStorage.AddSubject(subject);
            Console.WriteLine("Subject added successfully!");
        }

        static void AddStudentToClassSection(SchoolDataStorage dataStorage)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter class and section: ");
            string classAndSection = Console.ReadLine();

            var student = dataStorage.GetStudents().FirstOrDefault(s => s.Name == name && s.ClassAndSection == classAndSection);
            if (student == null)
            {
                Console.WriteLine("Student not found for the given name and class section. Please add the student first.");
                return;
            }

            var classSection = dataStorage.GetClassSections().FirstOrDefault(cs => cs.Name == classAndSection);
            if (classSection == null)
            {
                classSection = new ClassSection { Name = classAndSection };
                dataStorage.AddClassSection(classSection);
            }

            dataStorage.AddStudentToClassSection(student, classSection);
            Console.WriteLine("Student added to class section successfully!");
        }

        static void AddTeacherToClassSection(SchoolDataStorage dataStorage)
        {
            Console.Write("Enter teacher name: ");
            string name = Console.ReadLine();
            Console.Write("Enter class and section: ");
            string classAndSection = Console.ReadLine();

            var teacher = dataStorage.GetTeachers().FirstOrDefault(t => t.Name == name && t.ClassAndSection == classAndSection);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found for the given name and class section. Please add the teacher first.");
                return;
            }

            var classSection = dataStorage.GetClassSections().FirstOrDefault(cs => cs.Name == classAndSection);
            if (classSection == null)
            {
                classSection = new ClassSection { Name = classAndSection };
                dataStorage.AddClassSection(classSection);
            }

            dataStorage.AddTeacherToClassSection(teacher, classSection);
            Console.WriteLine("Teacher added to class section successfully!");
        }

        static void DisplayStudentsInClassSection(SchoolDataStorage dataStorage)
        {
            Console.Write("Enter class and section: ");
            string classAndSection = Console.ReadLine();

            var classSection = dataStorage.GetClassSections().FirstOrDefault(cs => cs.Name == classAndSection);
            if (classSection == null)
            {
                Console.WriteLine("Class section not found for the given name. Please add students to the class section first.");
                return;
            }

            var studentsInClassSection = dataStorage.GetStudentsInClassSection(classSection);
            Console.WriteLine($"Students in class {classAndSection}:");
            foreach (var student in studentsInClassSection)
            {
                Console.WriteLine($"- {student.Name}");
            }
        }

        static void DisplaySubjectsTaughtByTeacher(SchoolDataStorage dataStorage)
        {
            Console.Write("Enter teacher name: ");
            string name = Console.ReadLine();
            Console.Write("Enter class and section: ");
            string classAndSection = Console.ReadLine();

            var teacher = dataStorage.GetTeachers().FirstOrDefault(t => t.Name == name && t.ClassAndSection == classAndSection);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found for the given name and class section. Please add the teacher first.");
                return;
            }

            var subjectsTaughtByTeacher = dataStorage.GetSubjectsTaughtByTeacher(teacher);
            Console.WriteLine($"Subjects taught by {teacher.Name}:");
            foreach (var subject in subjectsTaughtByTeacher)
            {
                Console.WriteLine($"- {subject.Name} ({subject.SubjectCode})");
            }
        }
    }
}



