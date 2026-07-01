using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.Infrastructure.Entities;

namespace EmployeeManagement.Infrastructure.Mappings;

public static class EmployeeMapper
{
    public static EmployeeDto ToDto(Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Salary = employee.Salary,
            DepartmentId = employee.DepartmentId,
            DepartmentName = employee.Department?.Name ?? string.Empty
        };
    }
}
