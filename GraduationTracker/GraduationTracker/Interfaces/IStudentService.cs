using System.Collections.Generic;

namespace GraduationTracker.Interfaces
{

    public interface IStudentService
        {
            void AddStudent(IStudent student);
            IStudent GetStudent(int id);
            List<IStudent> GetAllStudents();
        }
    
}
