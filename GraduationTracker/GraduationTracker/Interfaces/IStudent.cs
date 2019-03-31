namespace GraduationTracker.Interfaces
{
    public interface IStudent :IEntity
    {
        ICourse[] Courses { get; set; }
        STANDING Standing { get; set; }
    }
}
