using AcademyApp.Business.ViewModel;
using System.Collections.Generic;

namespace AcademyApp.Business.Interfaces
{
    public interface IGroupService
    {
        void Create(GroupViewModel group);
        void Update(GroupViewModel group);
        void Delete(int groupId, int academyProgramId);
        IEnumerable<GroupViewModel> GetAll(int academyProgramId);
        GroupViewModel FindById(int apId);
    }
}
