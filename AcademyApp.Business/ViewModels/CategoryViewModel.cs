using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.ViewModels
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<SubCategoryViewModel> SubCategories { get; set; }
    }
}
