using GraduationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _repository;

        public StudentService()
        {
            _repository = StudentRepository.Instance;
        }

        public StudentService(IStudentRepository studentRepository)
        {
            _repository = studentRepository;

        }

        public void AddStudent(IStudent student)
        {
            _repository.AddStudent(student);
        }

        public List<IStudent> GetAllStudents()
        {
            return _repository.GetStudents();
        }

        public IStudent GetStudent(int id)
        {
            var students = _repository.GetStudents();
            IStudent student = null;

            for (int i = 0; i < students.ToArray().Length; i++)
            {
                if (id == students[i].Id)
                {
                    student = students[i];
                }
            }
            return student;
        }
    }
}
