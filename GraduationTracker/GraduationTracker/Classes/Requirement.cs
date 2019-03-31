using GraduationTracker.Interfaces;
namespace GraduationTracker
{
    public class Requirement : IRequirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public int[] Courses { get; set; }
    }
}

