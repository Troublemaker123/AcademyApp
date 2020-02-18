using AcademyApp.Api.Utility;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Api.Controllers
{

    [Route("api/[controller]")]
    [ValidateModel]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly IClassRoomService _classRoomService;
        private readonly INonWorkingDayService _nonWorkingDayService;

        public AdminController(           
            IRoleService roleService,
            IUserService userService,
            IClassRoomService classRoomService,
            INonWorkingDayService nonWorkingDayService
            )
        {            
            _roleService = roleService;
            _userService = userService;
            _classRoomService = classRoomService;
            _nonWorkingDayService = nonWorkingDayService;
        }

        public IActionResult Start()
        {
            return Ok("web api started..");
        }
      

        #region Roles
        [Route("role/create")]
        [HttpPost]
        public ActionResult CreateRole(RoleViewModel role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }

                _roleService.Create(role);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("role/delete/{roleId}")]
        [HttpDelete]
        public ActionResult DeleteRole(int roleId)
        {
            try
            {
                _roleService.Delete(roleId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("role/find-by-id/{roleId}")]
        public ActionResult FindRoleById(int roleId)
        {
            try
            {
                var role = _roleService.FindById(roleId);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("role/get-all")]
        public IActionResult GetAllRoles()
        {
            try
            {
                var roles = _roleService.GetAll();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("role/update")]
        [HttpPut]
        public IActionResult UpdateRole(RoleViewModel role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _roleService.Update(role);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Users
        [Route("user/create")]
        [HttpPost]
        public ActionResult CreateUser(UserViewModel user)
        {
            try
            {
                _userService.Create(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("user/delete/{userId}")]
        [HttpDelete]
        public ActionResult DeleteUser(int userId)
        {
            try
            {
                _userService.Delete(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("user/find-by-id/{userId}")]
        public ActionResult FindUserById(int userId)
        {
            try
            {
                var user = _userService.FindById(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [Route("user/get-all")]
        public ActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("user/update")]
        [HttpPut]
        public ActionResult UpdateUser(UserViewModel user)
        {
            try
            {             
                _userService.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("user/print/{userId}")]
        [HttpGet]
        public ActionResult PrintCredntials(int userId)
        {
            try
            {             
                _userService.PrintLoginCredentials(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region ClassRooms
        [Route("classroom/create")]
        [HttpPost]
        public ActionResult CreateClassRoom(ClassRoomViewModel classRoom)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }

                _classRoomService.Create(classRoom);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("classroom/delete/{classroomId}")]
        [HttpDelete]
        public ActionResult DeleteClassRoom(int classroomId)
        {
            try
            {
                _classRoomService.Delete(classroomId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("classroom/find-by-id/{classroomId}")]
        public ActionResult FindClassRoomById(int classroomId)
        {
            try
            {
                var classRoom = _classRoomService.FindById(classroomId);
                return Ok(classRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("classroom/get-all")]
        public IActionResult GetAllClassRooms()
        {
            try
            {
                var roles = _classRoomService.GetAll();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("classroom/update")]
        [HttpPut]
        public IActionResult UpdateClassRoom(ClassRoomViewModel classRoom)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _classRoomService.Update(classRoom);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Non Working Days
        [Route("nonworkingday/create")]
        [HttpPost]
        public ActionResult CreateNonWorkingDay(NonWorkingDayViewModel day)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }

                _nonWorkingDayService.Create(day);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("nonworkingday/delete/{nonworkingdayId}")]
        [HttpDelete]
        public ActionResult DeleteNonWorkingDay(int nonworkingday)
        {
            try
            {
                _nonWorkingDayService.Delete(nonworkingday);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("nonworkingday/find-by-id/{nonworkingdayId}")]
        public ActionResult FindNonWorkingDayById(int nonworkingdayId)
        {
            try
            {
                var day = _nonWorkingDayService.FindById(nonworkingdayId);
                return Ok(day);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("nonworkingday/get-all/{academyProgramId}")]
        public IActionResult GetAllNonWorkingDays(int academyProgramId)
        {
            try
            {
                var roles = _nonWorkingDayService.GetAll(academyProgramId);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("nonworkingday/update")]
        [HttpPut]
        public IActionResult UpdateNonWorkingDay(NonWorkingDayViewModel day)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _nonWorkingDayService.Update(day);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}