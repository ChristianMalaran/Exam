using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Interfaces;
using Vidly.Models;

namespace Vidly.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
       

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public Employees CreateEmployees(Employees employees)
        {
            employees.Firstname = employees.Firstname.Trim();
            employees.Middlename = employees.Middlename.Trim();
            employees.Lastname = employees.Lastname.Trim();

            _context.Add(employees);

            _context.SaveChanges();
            return employees;
        }
        public ICollection<Employees> GetEmployees()
        {
            var employeess = _context.Employee.OrderByDescending(p => p.Id).ToList();

            foreach (var employees in employeess)
            {
                employees.Firstname = employees.Firstname.Trim();
                employees.Middlename = employees.Middlename.Trim();
                employees.Lastname = employees.Lastname.Trim();
            }

            return employeess;
        }

        public bool employeesExist(int employeesId)
        {
            return _context.Employee.Any(p => p.Id == employeesId);
        }

        public Employees GetEmployeeById(int id)
        {
           

            //return (employees)_context.employees.Where(p => ids.Contains(p.Id));

            var employees =  _context.Employee.Where(p => p.Id == id).FirstOrDefault();
            
            employees.Firstname = employees.Firstname.Trim();
            employees.Middlename = employees.Middlename.Trim();
            employees.Lastname = employees.Lastname.Trim();
            return employees;
        }







        public bool UpdateEmployees(Employees employees, int employeesId)
        {
            _context.Update(employees);
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool DeleteEmployee(int employeeId)
        {
            var employees = _context.Employee.Where(p => p.Id == employeeId).FirstOrDefault();

            if (employees == null)
            {
                return false;
            }
            _context.Remove(employees);
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }


    }
}
