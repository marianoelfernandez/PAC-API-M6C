﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this._studentLogic = studentLogic;
        }

      [HttpGet]
      public IActionResult Students()
        {
            var students =  _studentLogic.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            return Ok(_studentLogic.GetStudentById(id));

        }

       [HttpPost]
       [AuthenticationRequired]
        public IActionResult Students(Student student)
        {
            _studentLogic.InsertStudents(student);
            return Ok();
        }

    }
}
