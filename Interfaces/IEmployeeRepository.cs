using Vidly.Models;

namespace Vidly.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employees> GetEmployees();

        Employees GetEmployeeById(int id);
      

        bool employeesExist(int employeesId);
        Employees CreateEmployees(Employees employees);

        bool UpdateEmployees(Employees employees, int employeesId);

        bool DeleteEmployee(int employeesId);


    }
}
