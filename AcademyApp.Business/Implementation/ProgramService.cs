using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Model;
using System;


namespace AcademyApp.Business.Implementation
{
    public class ProgramService : IProgramService
    {
        private readonly IRepository<Program> _program;
        public ProgramService(IRepository<Program> program)
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
