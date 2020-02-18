using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
using System.Linq;

namespace AcademyApp.Business
{
    public class AcademyProgramService : IAcademyProgramService
    {
        private readonly IRepository<AcademyProgram> _academyProgramRepository;
        private readonly IRepository<Academy> _academyrepository;

        public AcademyProgramService(IRepository<AcademyProgram> academyProgramRepository, IRepository<Academy> academyrepository)
        {
            _academyProgramRepository = academyProgramRepository;
            _academyrepository = academyrepository;
        }

        public void Create(AcademyProgramViewModel academyProgram)
        {
            if (academyProgram == null)
                throw new ApplicationException("academyProgram is null");

            var program = academyProgram.ToDomain();
            //program.CreatedBy = 1;
            program.Academy = _academyrepository.FindById(academyProgram.AcademyId);

            _academyProgramRepository.Create(program);
        }

        public IEnumerable<AcademyProgramViewModel> GetAll()
        {
            /*  var apList = _academyProgramRepository.GetAll().Select(
                   model =>
                   {
                       model.Academy = _academyrepository.FindById(model.AcademyId);
                       return model.ToModel();
                   }).ToList();*/

            var apList = _academyProgramRepository.GetAll().ToList();
            var resultList = apList.Select(
                    model =>
                    {
                        model.Academy = _academyrepository.FindById(model.AcademyId);
                        return model.ToModel();
                    }
                );
            return resultList;
        }

        public void Update(AcademyProgramViewModel academyProgram)
        {
            var program = _academyProgramRepository.FindById(academyProgram.ID);
            if (program == null)
                throw new Exception("academyProgram is null");

            program.StartDate = academyProgram.StartDate;
            program.EndDate = academyProgram.EndDate;
            program.IsCurrent = academyProgram.IsCurrent;
            program.AcademyId = academyProgram.AcademyId;
            program.Academy = _academyrepository.FindById(academyProgram.AcademyId);

            _academyProgramRepository.Update(program);
            // if this AP is set to Current, update the latest current AP to IsCurrent=false
            /*if (academyProgram.IsCurrent)
            {
                var academyPrograms = _academyProgramRepository.GetAll().Where(ap => ap.IsCurrent && ap.ID != program.ID).ToList();
                foreach (var item in academyPrograms)
                {
                    item.IsCurrent = false;
                    _academyProgramRepository.Update(item);
                }
            }*/
        }

        public AcademyProgramViewModel FindById(int academyProgramId)
        {
            var program = _academyProgramRepository.FindById(academyProgramId);
            if (program == null)
                throw new Exception("academyProgramId not found");
            program.Academy = _academyrepository.FindById(program.AcademyId);

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

        public void Delete(int academyProgramId)
        {
            var program = _academyProgramRepository.FindById(academyProgramId);
            if (program == null)
                throw new Exception("academyProgram not found");

            _academyProgramRepository.Delete(program);
        }

    }

}
