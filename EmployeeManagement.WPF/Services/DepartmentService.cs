using EmployeeManagement.Core.DTOs.Department;
using System.Net.Http;
using System.Net.Http.Json;

namespace EmployeeManagement.WPF.Services;

public class DepartmentService
{
    private readonly HttpClient _httpClient;

    public DepartmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DepartmentDto>?> GetDepartmentsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<DepartmentDto>>("api/Department");
    }
}