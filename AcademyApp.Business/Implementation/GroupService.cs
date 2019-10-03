using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Business.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> _groupRepository;


        public GroupService(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }


        public void Create(GroupViewModel model)
        {
            if(model == null)
                throw new ApplicationException("group is null");

            var domain = model.ToDomain();
            _groupRepository.Create(domain);
        }

        public void Delete(int groupId, int academyProgramId)
        {
            var group = _groupRepository.FindByMultipleId(groupId, academyProgramId);
            if(group == null)
                throw new Exception("groupId is null");
            _groupRepository.Delete(group);
        }

        public GroupViewModel FindById(int groupId)
        {
            var group = _groupRepository.FindById(groupId);
            if (group == null)
                throw new Exception("GroupId not found");

            return group.ToModel();
        }


        public IEnumerable<GroupViewModel> GetAll(int academyProgramId)
        {
            return _groupRepository.GetAll().Where(model => model.ApId == academyProgramId)
                .Select(model => model.ToModel()).ToList();
        }


        public void Update(GroupViewModel model)
        {
            var group = _groupRepository.FindByMultipleId(model.ID,model.AcademyProgramId);
            if (group == null)
                throw new Exception();

            group.ID = group.ID;
            group.Title = group.Title;

            _groupRepository.Update(group);
        }
    }
}
