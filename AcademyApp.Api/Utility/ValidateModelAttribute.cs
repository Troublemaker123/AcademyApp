﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyApp.Api.Utility
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                   .SelectMany(v => v.Errors)
                   .Select(v => v.ErrorMessage)
                   .ToList();

                var responseObj = new
                {
                    Message = "Validation Error",
                    Errors = errors
                };

                context.Result = new JsonResult(responseObj)
                {
                    StatusCode = 405
                };
            }
        }
    }
}
