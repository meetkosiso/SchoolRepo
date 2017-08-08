using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eschool.Data.Abstract;
using AutoMapper;
using Eschool.ViewModels;
using Eschool.Model.Entities;



namespace Eschool.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;


        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult Get(int id)
        {
            var _student = _studentRepository.GetSingle(x => x.Id == id, x => x.ParentPhone, x => x.Name, x => x.classes);
            if (_student != null)
            {
              StudentViewModel   _studentVM = Mapper.Map<Student, StudentViewModel>(_student);
                return new OkObjectResult(_studentVM);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody]StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student _newstudent = Mapper.Map<StudentViewModel, Student>(student);
          

            _studentRepository.Add(_newstudent);
            _studentRepository.Commit();

           

            student = Mapper.Map<Student, StudentViewModel>(_newstudent);

            CreatedAtRouteResult result = CreatedAtRoute("GetStudent", new { controller = "Student", id = student.Studentid }, student);
            return result;
        }

    }
    
}
    