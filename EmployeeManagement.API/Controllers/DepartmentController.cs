using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Core.DTOs.Department;
using EmployeeManagement.Core.Services.Interfaces;

namespace EmployeeManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _repository;

    public DepartmentController(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _repository.GetAllAsync();
        return Ok(departments);
    }
}