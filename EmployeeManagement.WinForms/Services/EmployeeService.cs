using EmployeeManagement.Core.DTOs.Employee;
using System.Net.Http.Json;

namespace EmployeeManagement.WinForms.Services;

public class EmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EmployeeDto>?> GetEmployeesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<EmployeeDto>>("api/Employee");
    }

    public async Task<bool> CreateEmployeeAsync(CreateEmployeeDto employee)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Employee", employee);

        return response.IsSuccessStatusCode;
    }

    public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<EmployeeDto>($"api/Employee/{id}");
    }


    public async Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto employee)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Employee/{id}", employee);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Employee/{id}");

        return response.IsSuccessStatusCode;
    }

    
}