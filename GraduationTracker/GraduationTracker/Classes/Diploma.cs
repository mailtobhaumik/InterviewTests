using GraduationTracker.Interfaces;

namespace GraduationTracker
{
    public class Diploma : IDiploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public int[] Requirements { get; set; }
    }
}
