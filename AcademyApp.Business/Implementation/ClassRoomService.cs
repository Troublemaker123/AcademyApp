using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Business.Implementation
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IRepository<Classroom> _classroomRepository;
        public ClassRoomService(IRepository<Classroom> classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }
        public void Create(ClassRoomViewModel model)
        {
            _classroomRepository.Create(model.ToDomain());
        }

        public void Delete(int cId)
        {
            var classroom = _classroomRepository.FindById(cId);
            if (classroom == null)
                throw new Exception("Classroom not found");

            _classroomRepository.Delete(classroom);
        }

        public ClassRoomViewModel FindById(int cId)
        {
            var classroom = _classroomRepository.FindById(cId);
            if (classroom == null)
                throw new ApplicationException("Classroom not found.");

            return classroom.ToModel();
        }

        public IEnumerable<ClassRoomViewModel> GetAll()
        {
            return _classroomRepository.GetAll().Select(
                model => model.ToModel()
          ).ToList();
        }

        public void Update(ClassRoomViewModel model)
        {
            var classroom = _classroomRepository.FindById(model.Id);
            if (classroom == null)
                throw new Exception();

            classroom.Name = model.Name;
            classroom.Location = model.Location;

            _classroomRepository.Update(classroom);
        }
    }
}
