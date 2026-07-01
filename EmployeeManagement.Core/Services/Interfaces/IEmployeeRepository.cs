using EmployeeManagement.Core.DTOs.Employee;

namespace EmployeeManagement.Core.Services.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync();

    Task<EmployeeDto?> GetByIdAsync(int id);

    Task<EmployeeDto> AddAsync(CreateEmployeeDto employeeDto);

    Task<bool> UpdateAsync(int id, UpdateEmployeeDto employeeDto);

    Task DeleteAsync(int id);
}