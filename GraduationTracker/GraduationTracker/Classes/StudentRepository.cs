using GraduationTracker.Interfaces;
using System.Collections.Generic;

namespace GraduationTracker
{
    public  class StudentRepository : IStudentRepository
    {
        private List<IStudent> _studentList;
        private static readonly object _objlock = new object();
        private static IStudentRepository _instance = null;

        StudentRepository()
        {
            _studentList = new List<IStudent>();
        }

        public static IStudentRepository Instance
        {
            get
            {
                lock (_objlock)
                {
                    if (_instance == null)
                    {
                        _instance = new StudentRepository();
                    }
                    return _instance;
                }
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