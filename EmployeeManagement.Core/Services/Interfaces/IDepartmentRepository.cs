using EmployeeManagement.Core.DTOs.Department;

namespace EmployeeManagement.Core.Services.Interfaces;

public interface IDepartmentRepository
{
    Task<IEnumerable<DepartmentDto>> GetAllAsync();
}