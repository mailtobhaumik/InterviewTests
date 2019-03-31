using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interfaces
{
    public interface IDiplomaService
    {
        void AddDiploma(IDiploma diploma);
        IDiploma GetDiploma(int id);
        void AddRequirement(IRequirement requirement);
        IRequirement GetRequirement(int id);
    }
}
