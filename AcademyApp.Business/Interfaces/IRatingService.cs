using AcademyApp.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
   public interface IRatingService
    {
        void Create(RatingViewModel model);
        void Update(RatingViewModel model);
       // IEnumerable<RatingViewModel> GetAll();
        RatingViewModel FindById(int rId);
        void Delete(int rId);
    }
}
