using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_School_Data_Design_Practice_Project
{
    public class SchoolDataStorage
    {
        private static SchoolDataStorage _instance;
        private List<IStudent> students = new List<IStudent>();
        private List<ITeacher> teachers = new List<ITeacher>();
        private List<ISubject> subjects = new List<ISubject>();
        private List<IClassSection> classSections = new List<IClassSection>();

        private SchoolDataStorage() { }

        public static SchoolDataStorage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SchoolDataStorage();
            }
            return _instance;
        }

        public void AddStudent(IStudent student)
        {
            students.Add(student);
        }

        public void AddTeacher(ITeacher teacher)
        {
            teachers.Add(teacher);
        }

        public void AddSubject(ISubject subject)
        {
            subjects.Add(subject);
            NotifyTeachers(subject);
        }

        private void NotifyTeachers(ISubject subject)
        {
            foreach (var teacher in teachers)
            {
                if (teacher.ClassAndSection == subject.Teacher.ClassAndSection)
                {
                    ITeacherObserver observer = new SubjectObserver(teacher);
                    observer.Update(subject);
                }
            }
        }

        public void AddStudentToClassSection(IStudent student, IClassSection classSection)
        {
            classSection.Students.Add(student);
        }

        public void AddTeacherToClassSection(ITeacher teacher, IClassSection classSection)
        {
            classSection.Teachers.Add(teacher);
        }

        public List<IStudent> GetStudentsInClassSection(IClassSection classSection)
        {
            return classSection.Students;
        }

        public List<ISubject> GetSubjectsTaughtByTeacher(ITeacher teacher)
        {
            return subjects.FindAll(subject => subject.Teacher == teacher);
        }

        // Getters for the lists of students, teachers, subjects, and class sections
        public List<IStudent> GetStudents()
        {
            return students;
        }

        public List<ITeacher> GetTeachers()
        {
            return teachers;
        }

        public List<ISubject> GetSubjects()
        {
            return subjects;
        }

        public List<IClassSection> GetClassSections()
        {
            return classSections;
        }

        public void AddClassSection(IClassSection classSection)
        {
            classSections.Add(classSection);
        }
    }

}
