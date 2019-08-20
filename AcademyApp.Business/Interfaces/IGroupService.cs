﻿using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface IGroupService
    {
        void Create(GroupViewModel model);
        void Update(GroupViewModel model);
        List<GroupViewModel> FindAll();
        GroupViewModel FindById(int apId);
    }
}