using EmployeeManagement.Infrastructure.Entities;
using EmployeeManagement.Core.Services.Interfaces;
using EmployeeManagement.Infrastructure.Persistence.Data;
using EmployeeManagement.Core.DTOs.Department;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        return await _context.Departments
            .AsNoTracking()
            .Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name
            })
            .ToListAsync();
    }
}