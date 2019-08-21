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
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> _apRepository;

        public StaffService(IRepository<Staff> apRepository)
        {
            _apRepository = apRepository;
        }

            public void Create(StaffViewModel model)
            {
            var domain = model.ToDomain();
            _apRepository.Create(domain);
        }

            public IEnumerable<StaffViewModel> GetAll()
            {
            return _apRepository.GetAll().Select(model => new StaffViewModel()
            {
                ID = model.ID,

            }
           ).ToList();
        }

            public StaffViewModel FindById(int apId)
            {
                throw new NotImplementedException();
            }

            public void Update(StaffViewModel model)
            {
                var program = _apRepository.FindById(new Staff());
                if (program == null)
                    throw new Exception();

                _apRepository.Update(program);
            }
        }
    }

