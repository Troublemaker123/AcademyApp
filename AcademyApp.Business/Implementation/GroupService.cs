using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Business.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<GroupStudents> _groupMembersRepository;
        private readonly IRepository<AcademyProgram> _academyProgramrepository;
        private readonly IRepository<Academy> _academyRepository;


        public GroupService(IRepository<Group> groupRepository,
            IRepository<GroupStudents> groupMembersRepository,
            IRepository<AcademyProgram> academyProgramrepository,
            IRepository<Academy> academyRepository)
        {
            _groupRepository = groupRepository;
            _groupMembersRepository = groupMembersRepository;
            _academyProgramrepository = academyProgramrepository;
            _academyRepository = academyRepository;
        }


        public void Create(GroupViewModel model)
        {
            if(model == null)
                throw new ApplicationException("group is null");
            _groupRepository.Create(model.ToDomain());
        }

        public void Delete(int groupId)
        {
            var group = _groupRepository.FindById(groupId);
            if (group == null)
                throw new Exception("Role not found");

            _groupRepository.Delete(group);
        }

        public GroupViewModel FindById(int groupId)
        {
            var group = _groupRepository.FindById(groupId);
            group.AcademyProgram = _academyProgramrepository.FindById(group.AcademyProgramId);
            if (group == null)
                throw new Exception("GroupId not found");

            return group.ToModel();
        }


        public IEnumerable<GroupViewModel> GetAll(int academyProgramId)
        {
            var apList = _groupRepository.GetAll().Where(ap => ap.AcademyProgramId == academyProgramId).ToList();
            var resultList = apList.Select(
                    model =>
                    {
                        model.AcademyProgram = _academyProgramrepository.FindById(model.AcademyProgramId);
                        model.AcademyProgram.Academy = _academyRepository.FindById(model.AcademyProgram.AcademyId);
                        return model.ToModel();
                    }
                );
            return resultList;
        }

        public void Update(GroupViewModel model)
        {
            var group = _groupRepository.FindById(model.ID); //_groupRepository.FindByMultipleId(model.ID, model.AcademyProgramId);
            if (group == null)
                throw new Exception();

            group.Name = model.Name;
            group.AcademyProgramId = model.AcademyProgramId;
            group.AcademyProgram = _academyProgramrepository.FindById(model.AcademyProgramId);

            _groupRepository.Update(group);
        }
    }
}
