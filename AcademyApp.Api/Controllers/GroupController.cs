using System;
using System.Collections.Generic;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }


        [Route("create")]
        [HttpPost]
        public ActionResult Create(GroupViewModel group)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupService.Create(group);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("delete/{groupId}/{academyProgramId}")]
        [HttpDelete]
        public ActionResult Delete(int groupId, int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupService.Delete(groupId,academyProgramId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [Route("update")]
        [HttpPut]
        public ActionResult Update(GroupViewModel group)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupService.Update(group);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [Route("find-by-id/{studentId}")]
        [HttpGet]
        public ActionResult<GroupViewModel> FindById(int groupId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var students = _groupService.FindById(groupId);
                return Ok(students);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST api/group/get-all
        [Route("get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<GroupViewModel>> GetAll(int groupId, int academyProgramId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var groups = _groupService.GetAll(academyProgramId);
                return Ok(groups);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}