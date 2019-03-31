using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interfaces
{
    public interface IDiplomaRepository
    {
        void AddDiploma(IDiploma diploma);
        void AddRequirement(IRequirement requirement);
        List<IDiploma> GetDiplomas();
        List<IRequirement> GetRequirements();
    }
}
