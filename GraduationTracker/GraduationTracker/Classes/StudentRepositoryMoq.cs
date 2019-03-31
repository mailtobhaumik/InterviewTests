using GraduationTracker.Interfaces;
using System.Collections.Generic;

namespace GraduationTracker
{
    public class StudentRepositoryMoq : IStudentRepository
    {
        private List<IStudent> _studentList;

        StudentRepositoryMoq()
        {
            _studentList = new List<IStudent>();
        }

        public static IStudentRepository Instance
        {
            get
            {
                return new StudentRepositoryMoq();
            }
        }

        public List<IStudent> GetStudents()
        {
            //Get Data From Data Source
            return _studentList;
        }

        public void AddStudent(IStudent student)
        {
            _studentList.Add(student);
        }

    }

}
