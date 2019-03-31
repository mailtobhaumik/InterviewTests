using GraduationTracker.Interfaces;
using System.Collections.Generic;

namespace GraduationTracker
{
    public class DiplomaRepositoryMoq : IDiplomaRepository
    {
        private List<IDiploma> _diplomaList;
        private List<IRequirement> _requirementList;

        DiplomaRepositoryMoq()
        {
            _diplomaList = new List<IDiploma>();
            _requirementList = new List<IRequirement>();
        }

        public static IDiplomaRepository Instance
        {
            get
            {
                return new DiplomaRepositoryMoq();
            }
        }

        public List<IDiploma> GetDiplomas()
        {
            return _diplomaList;
        }

        public List<IRequirement> GetRequirements()
        {
            return _requirementList;
        }

        public void AddDiploma(IDiploma diploma)
        {
            _diplomaList.Add(diploma);
        }

        public void AddRequirement(IRequirement requirement)
        {
            _requirementList.Add(requirement);
        }
    }
}
