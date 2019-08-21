﻿using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;


namespace AcademyApp.Business
{
    public interface IStudentService
    {
        void CreateStudent(StudentViewModel model);
        void Update(StudentViewModel model);
        IEnumerable<AttendanceViewModel> GetAll();
        StudentViewModel FindById(int apId);

    }
}
