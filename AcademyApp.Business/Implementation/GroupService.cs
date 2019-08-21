using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Business.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> _apRepository;

        public GroupService(IRepository<Group> apRepository)
        {
            _apRepository = apRepository;
        }
        public void Create(GroupViewModel model)
        {
            var domain = model.ToDomain();
            _apRepository.Create(domain);
        }

        public GroupViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AttendanceViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => new AttendanceViewModel()
            {
                ID = model.ID,

            }
            ).ToList();
        }

        public void Update(GroupViewModel model)
        {
            var program = _apRepository.FindById(new Group());
            if (program == null)
                throw new Exception();
            _apRepository.Update(program);
        }
    }
}
