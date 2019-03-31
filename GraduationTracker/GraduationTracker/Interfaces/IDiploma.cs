using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interfaces
{
    public interface IDiploma : IEntity
    {
        int Credits { get; set; }
        int[] Requirements { get; set; }
    }
}
