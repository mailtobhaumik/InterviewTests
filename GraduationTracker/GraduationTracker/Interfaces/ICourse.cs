using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interfaces
{
    public interface ICourse : IEntity
    {     
        string Name { get; set; }
        int Mark { get; set; }
        int Credits { get; }
    }
}
