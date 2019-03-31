using GraduationTracker.Interfaces;
using System;

namespace GraduationTracker
{
    public partial class GraduationTracker : IGraduationTracker
    {
        public struct Result
        {
            public int Credit { get; set; }
            public double Average { get; set; }
            public bool IsValid { get; set; }
        }
        /// Use dependency injection for repository so that it can be mocked when testing.
        IRepository repository;
        public GraduationTracker(IRepository repository)
        {
            this.repository = repository;
        }

        private IDiplomaService _service;

        public GraduationTracker(IDiplomaService diplomaService)
        {
            _service = diplomaService;
        }


        private Result Evaluateresult(IDiploma diploma, IStudent student)
        {
            Result result = new Result { IsValid = true };
            bool courseTaken = false;

            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                var requirement = _service.GetRequirement(diploma.Requirements[i]);
                for (int k = 0; k < requirement.Courses.Length; k++)
                {
                    courseTaken = false;
                    for (int j = 0; j < student.Courses.Length; j++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            result.Average += student.Courses[j].Mark;
                            if (student.Courses[j].Mark >= requirement.MinimumMark)
                            {
                                result.Credit += requirement.Credits;
                            }
                            courseTaken = true;
                            break;
                        }
                    }
                    if (!courseTaken)
                    {
                        result.IsValid = false;
                        return result;
                    }
                }
            }

            result.Average = result.Average / student.Courses.Length;

            return result;
        }

        public Tuple<bool, STANDING> HasGraduated(IDiploma diploma, IStudent student)
        {
            var standing = STANDING.None;
            var result = Evaluateresult(diploma, student);

            if (!result.IsValid)
            {
                return new Tuple<bool, STANDING>(false, standing);
            }

            standing = CalculateStanding(result.Average);
            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.SummaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);

                default:
                    return new Tuple<bool, STANDING>(false, standing);
            }
        }

        /// <summary>
        /// Separate method so that the code can be tested
        /// </summary>
        /// <param name="average"></param>
        /// <returns></returns>
        public STANDING CalculateStanding(double average)
        {
            var standing = STANDING.None;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average >= 50 && average < 80)
                standing = STANDING.Average;
            else if (average >= 80 && average < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.SummaCumLaude;

            return standing;
        }
    }
   
}

