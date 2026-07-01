using EmployeeManagement.Infrastructure.Entities;
using EmployeeManagement.Core.Services.Interfaces;
using EmployeeManagement.Infrastructure.Persistence.Data;
using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<EmployeeDto> AddAsync(CreateEmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary,
                DepartmentId = employeeDto.DepartmentId,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            if (employee.DepartmentId > 0)
            {
                employee.Department = await _context.Departments.FindAsync(employee.DepartmentId);
            }

            return EmployeeMapper.ToDto(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return;

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .AsNoTracking()
                .ToListAsync();

            return employees.Select(EmployeeMapper.ToDto);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            return employee != null ? EmployeeMapper.ToDto(employee) : null;
        }

        public async Task<bool> UpdateAsync(int id, UpdateEmployeeDto employeeDto)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);

            if (existingEmployee == null)
                return false;

            existingEmployee.FirstName = employeeDto.FirstName;
            existingEmployee.LastName = employeeDto.LastName;
            existingEmployee.Email = employeeDto.Email;
            existingEmployee.Salary = employeeDto.Salary;
            existingEmployee.DepartmentId = employeeDto.DepartmentId;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
