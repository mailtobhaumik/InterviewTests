using System;

namespace GraduationTracker.Interfaces
{

    public interface IGraduationTracker
    {

        Tuple<bool, STANDING> HasGraduated(IDiploma diploma, IStudent student);

        STANDING CalculateStanding(double average);

    }
   
}
