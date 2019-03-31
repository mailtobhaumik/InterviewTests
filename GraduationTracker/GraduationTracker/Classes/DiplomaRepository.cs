using GraduationTracker.Interfaces;
using System.Collections.Generic;

namespace GraduationTracker
{
    public sealed class DiplomaRepository : IDiplomaRepository
    {
        private List<IDiploma> _diplomaList;
        private List<IRequirement> _requirementList;

        private static readonly object _objlock = new object();
        private static IDiplomaRepository _instance = null;

        DiplomaRepository()
        {
            _diplomaList = new List<IDiploma>();
            _requirementList = new List<IRequirement>();
        }

        public static IDiplomaRepository Instance
        {
            get
            {
                lock (_objlock)
                {
                    if (_instance == null)
                    {
                        _instance = new DiplomaRepository();
                    }
                    return _instance;
                }
            }
        }

        public List<IDiploma> GetDiplomas()
        {
            //Get Data From Data Source
            return _diplomaList;
        }

        public List<IRequirement> GetRequirements()
        {
            //Get Data From Data Source
            return _requirementList;
        }

        public void AddDiploma(IDiploma diploma)
        {
            //Add Data To Data Source
            _diplomaList.Add(diploma);
        }

        public void AddRequirement(IRequirement requirement)
        {
            //Add Data To Data Source
            _requirementList.Add(requirement);
        }
    }
}