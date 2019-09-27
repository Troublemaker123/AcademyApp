using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Model;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
using System.Linq;

namespace AcademyApp.Business
{
    public class AcademyProgramService : IAcademyProgramService
    {
        private readonly IRepository<AcademyProgram> _academyProgramRepository;

        public AcademyProgramService(IRepository<AcademyProgram> academyProgramRepository)
        {
            _academyProgramRepository = academyProgramRepository;
        }

        public void Create(AcademyProgramViewModel academyProgram)
        {
            if (academyProgram == null)
                throw new ApplicationException("academyProgram is null");

            var program = academyProgram.ToDomain();
            program.CreatedOn = DateTime.Now;
            program.CreatedBy = "Administrator";

            _academyProgramRepository.Create(program);
        }

        public IEnumerable<AcademyProgramViewModel> GetAll()
        {
            return _academyProgramRepository.GetAll().Select(model => model.ToModel()).ToList();
        }

        public void Update(AcademyProgramViewModel academyProgram)
        {
            var program = _academyProgramRepository.FindById(academyProgram.Id);
            if (program == null)
                throw new Exception("academyProgram is null");

            program.StartDate = academyProgram.StartDate;
            program.EndDate = academyProgram.EndDate;
            program.IsCurrent = academyProgram.IsCurrent;

            _academyProgramRepository.Update(program);

            if (academyProgram.IsCurrent)
            {
                var academyPrograms = _academyProgramRepository.GetAll().Where(ap => ap.IsCurrent && ap.Id != program.Id).ToList();
                foreach (var item in academyPrograms)
                {
                    item.IsCurrent = false;
                    _academyProgramRepository.Update(item);
                }
            }

        }

        public AcademyProgramViewModel FindById(int academyProgramId)
        {
            var program = _academyProgramRepository.FindById(academyProgramId);
            if (program == null)
                throw new Exception("academyProgramId not found");

            return program.ToModel();
        }

        public void SetActive(int academyProgramId, bool active)
        {
            var program = _academyProgramRepository.FindById(academyProgramId);
            if (program == null)
                throw new Exception("academyProgramId is null");

            program.IsCurrent = active;

            _academyProgramRepository.SetActivity(active);
        }

        public void Delete(AcademyProgramViewModel academyProgram)
        {
            var program = _academyProgramRepository.FindById(academyProgram);
            if (program == null)
                throw new Exception("academyProgram not found");

            _academyProgramRepository.Delete(program);
        }

    }

}
