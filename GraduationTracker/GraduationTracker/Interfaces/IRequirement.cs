using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interfaces
{
    public interface IRequirement : IEntity
    {
        int[] Courses { get; set; }
        int Credits { get; set; }
        int MinimumMark { get; set; }
        string Name { get; set; }
    }    
}
