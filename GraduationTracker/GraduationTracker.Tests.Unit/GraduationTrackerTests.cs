using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Interfaces;
using Moq;
namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        static IGraduationTracker tracker;
        public TestContext TestContext { get; set; }
       
        static IStudentService _studentService;
        static IDiplomaService _diplomaService;
        static IStudentRepository _studentRepository;
        static IDiplomaRepository _diplomaRepository;

        private static void SetRequirements()
        {
            _diplomaService.AddRequirement(new Requirement { Id = 100, Name = "Math", MinimumMark = 50, Courses = new int[] { 1 }, Credits = 1 });
            _diplomaService.AddRequirement(new Requirement { Id = 102, Name = "Science", MinimumMark = 50, Courses = new int[] { 2 }, Credits = 1 });
            _diplomaService.AddRequirement(new Requirement { Id = 103, Name = "Literature", MinimumMark = 50, Courses = new int[] { 3 }, Credits = 1 });
            _diplomaService.AddRequirement(new Requirement { Id = 104, Name = "Physichal Education", MinimumMark = 50, Courses = new int[] { 4 }, Credits = 1 });
        }

        private static void SetDiploma()
        {
            _diplomaService.AddDiploma(new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            });
        }

        private void SetStudents1()
        {
            _studentService.AddStudent(new Student
            {
                Id = 1,
                Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                    }
            });
            _studentService.AddStudent(new Student
            {
                Id = 2,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
            });
            _studentService.AddStudent(new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            });
            _studentService.AddStudent(new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            });
        }

        private void SetStudents2()
        {
            _studentService.AddStudent(new Student
            {
                Id = 1,
                Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                    }
            });
            _studentService.AddStudent(new Student
            {
                Id = 2,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
            });
            _studentService.AddStudent(new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            });
        }


        /// <summary>
        /// Logs TestName to The console
        /// </summary>
        [TestInitialize]
        public void LogTests()
        {
            Console.WriteLine("TestContext.TestName = '{0}'", TestContext.TestName);
        }

        /// <summary>
        /// Initializes the Class Level Static Variables for Referencing it throughout the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _diplomaRepository = DiplomaRepositoryMoq.Instance;

            _diplomaService = new DiplomaService(_diplomaRepository);

            tracker = new GraduationTracker(_diplomaService);

            SetDiploma();
            SetRequirements();
        }

        /// <summary>
        /// Clean up the class level variables
        /// </summary>
        [ClassCleanup]
        public static void TestClean()
        {
            //tracker = null;
            
        }

        /// <summary>
        /// Verify if anyone graduated by removing the ones from the list who have diploma = false
        /// </summary>
        [TestMethod]
        public void TestHasGraduated()
        {
            var graduated = new List<Tuple<bool, STANDING>>();
            var expected = new List<Tuple<bool, STANDING>>();
            _studentRepository = StudentRepositoryMoq.Instance;
            _studentService = new StudentService(_studentRepository);

            SetStudents1();
            expected.Add(new Tuple<bool, STANDING>(true, STANDING.SummaCumLaude));
            expected.Add(new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude));
            expected.Add(new Tuple<bool, STANDING>(true, STANDING.Average));
            expected.Add(new Tuple<bool, STANDING>(false, STANDING.Remedial));
            foreach (var student in _studentService.GetAllStudents())
            {
                graduated.Add(tracker.HasGraduated(_diplomaService.GetDiploma(1), student));
            }
            int i = 0;
            foreach( var expect in expected )
            {
                Assert.AreEqual(graduated[i].Item1, expect.Item1);
                Assert.AreEqual(graduated[i].Item2, expect.Item2);
                i++;
            }
            
        }

        /// <summary>
        /// Test the return values from the GetStanding Method
        /// </summary>
        [TestMethod]
        public void TestGetStanding()
        {
            STANDING standing;

            standing = tracker.CalculateStanding(30);
            Assert.AreEqual("REMEDIAL", Convert.ToString(standing).ToUpper());

            standing = tracker.CalculateStanding(55);
            Assert.AreEqual("AVERAGE", Convert.ToString(standing).ToUpper());

            standing = tracker.CalculateStanding(85);
            Assert.AreEqual("MAGNACUMLAUDE", Convert.ToString(standing).ToUpper());

            standing = tracker.CalculateStanding(100);
            Assert.AreEqual("SUMMACUMLAUDE", Convert.ToString(standing).ToUpper());
        }

        [TestMethod]
        public void TestNotTakenRequirement()
        {
            _studentRepository = StudentRepositoryMoq.Instance;
            _studentService = new StudentService(_studentRepository);

            SetStudents2();

            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in _studentService.GetAllStudents())
            {
                graduated.Add(tracker.HasGraduated(_diplomaService.GetDiploma(1), student));
            }

            Assert.IsFalse(graduated.All(a => a.Item1));

            Assert.IsTrue(!graduated[1].Item1);
        }
    }
}


