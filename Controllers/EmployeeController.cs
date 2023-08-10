
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vidly.Dto;
using Vidly.Interfaces;
using Vidly.Models;
using Vidly.Repository;

namespace Vidly.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IMapper _mapper;

        public EmployeeController(
            IEmployeeRepository employeeRepository, 
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employees>))]
        public IActionResult GetEmployees() 
        {
            var employees = _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetEmployees());
           

        
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(200, Type = typeof(Employees))]
        [ProducesResponseType(204)]

        public IActionResult GetEmployees(int employeeId)
        {
            var employees = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployeeById(employeeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateEmployees([FromBody] EmployeeDto employeesCreate)
        {
            if (employeesCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeesMap = _mapper.Map<Employees>(employeesCreate);
            var employeesNew = _employeeRepository.CreateEmployees(employeesMap);
            if (employeesNew == null)
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("success create");
        }

        [HttpPut("{employeeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateEmployee([FromBody] EmployeeDto employeesUpdate, int employeeId)
        {
            if (employeesUpdate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeMap = _mapper.Map<Employees>(employeesUpdate);

            if (!_employeeRepository.UpdateEmployees(employeeMap, employeeId))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("success create");
        }

        [HttpDelete("{employeeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteEmployee(int employeeId)
        {
            if (employeeId == 0)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_employeeRepository.DeleteEmployee(employeeId))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("success create");
        }

       

    }
}
