using GraduationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class DiplomaService : IDiplomaService
    {
        private IDiplomaRepository _repository;

        public DiplomaService()
        {
            _repository = DiplomaRepository.Instance;
        }

        public DiplomaService(IDiplomaRepository diplomaRepository)
        {
            _repository = diplomaRepository;
        }

        public void AddDiploma(IDiploma diploma)
        {
            _repository.AddDiploma(diploma);
        }

        public void AddRequirement(IRequirement requirement)
        {
            _repository.AddRequirement(requirement);
        }

        public IDiploma GetDiploma(int id)
        {
            var diplomas = _repository.GetDiplomas();
            IDiploma diploma = null;

            for (int i = 0; i < diplomas.ToArray().Length; i++)
            {
                if (id == diplomas[i].Id)
                {
                    diploma = diplomas[i];
                }
            }
            return diploma;

        }

        public IRequirement GetRequirement(int id)
        {
            var requirements = _repository.GetRequirements();
            IRequirement requirement = null;

            for (int i = 0; i < requirements.ToArray().Length; i++)
            {
                if (id == requirements[i].Id)
                {
                    requirement = requirements[i];
                }
            }
            return requirement;
        }

    }
}
