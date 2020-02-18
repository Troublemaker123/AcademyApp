using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Implementation
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> _ratingRepository;

        public RatingService(IRepository<Rating> ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public void Create(RatingViewModel model)
        {
            _ratingRepository.Create(model.ToDomain());
        }

        public void Delete(int rId)
        {
            var rating = _ratingRepository.FindById(rId);
            if (rating == null)
                throw new Exception("Rating not found");

            _ratingRepository.Delete(rating);
        }

        public RatingViewModel FindById(int rId)
        {
            var rating = _ratingRepository.FindById(rId);
            if (rating == null)
                throw new ApplicationException("Rating not found.");

            return rating.ToModel();
        }

        public void Update(RatingViewModel model)
        {
            var rating = _ratingRepository.FindById(model.Id);
            if (rating == null)
                throw new Exception();

            rating.AcademyProgramId = model.AcademyProgramId;
            rating.MentorId = model.MentorId;
            rating.StudentId = model.StudentId;
            rating.SubjectId = model.SubjectId;
            rating.SubCategoryId = model.SubCategoryId;
            rating.Grade = model.Grade;
            rating.Comment = model.Comment;

            _ratingRepository.Update(rating);
        }
    }
}
