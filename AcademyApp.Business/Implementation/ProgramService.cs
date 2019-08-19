using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.ViewModel.AcademyApp.Business.Interfaces;
using AcademyApp.Data;


namespace AcademyApp.Business.Implementation
{
    public class ProgramService : IProgramService
    {
        private readonly IRepository<ProgramService> _program;
        public ProgramService(IRepository<ProgramService> program)
        {
            _program = program;
        }

        public void Create(ProgramViewModel model)
        {
            var domain = model.ToDomain();
            domain.Name = "Darko";
            _program.Create(domain);
        }
    }
}
