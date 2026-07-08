using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.Core.DTOs.Department;
using EmployeeManagement.WPF.ViewModels.Base;
using System.Windows.Input;
using EmployeeManagement.WPF.Commands;
using EmployeeManagement.WPF.Services;

namespace EmployeeManagement.WPF.ViewModels.Windows;

public class EmployeeDetailsViewModel : ViewModelBase
{
    private readonly DepartmentService _departmentService;
    private readonly EmployeeService _employeeService;
    private string _firstName = string.Empty;
    public event Action? RequestClose;
    public event Action? RequestCloseWithSuccess;
    public ICommand CancelCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }
    
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (SetProperty(ref _firstName, value))
            {
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    private string _lastName = string.Empty;
    public string LastName
    {
        get => _lastName;
        set
        {
            if (SetProperty(ref _lastName, value))
            {
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    public string FullName => $"{FirstName} {LastName}";

    private string _email = string.Empty;
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    private string _department = string.Empty;
    public string Department
    {
        get => _department;
        set => SetProperty(ref _department, value);
    }

    private decimal _salary;
    public decimal Salary
    {
        get => _salary;
        set => SetProperty(ref _salary, value);
    }

    private decimal _employeeId;
    public decimal EmployeeId
    {
        get => _employeeId;
        set => SetProperty(ref _employeeId, value);
    }

    private int _departmentId;
    public int DepartmentId
    {
        get => _departmentId;
        set
        {
            if (SetProperty(ref _departmentId, value))
            {
                var dept = Departments?.FirstOrDefault(d => d.Id == value);
                if (dept != null)
                {
                    Department = dept.Name;
                }
            }
        }
    }

    private List<DepartmentDto> _departments = [];
    public List<DepartmentDto> Departments
    {
        get => _departments;
        set => SetProperty(ref _departments, value);
    }

    public EmployeeDetailsViewModel(EmployeeDto employee, DepartmentService departmentService, EmployeeService employeeService)
    {
        _departmentService = departmentService;
        _employeeService = employeeService;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        Email = employee.Email;
        Department = employee.DepartmentName;
        Salary = employee.Salary;
        EmployeeId = employee.Id;
        DepartmentId = employee.DepartmentId;

        CancelCommand = new RelayCommand(_ =>
        {
            RequestClose?.Invoke();
        });

        SaveCommand = new RelayCommand(async _ => await SaveChangesAsync());
        DeleteCommand = new RelayCommand(async _ => await DeleteEmployeeAsync());
    }

    public async Task LoadDepartmentsAsync()
    {
        var depts = await _departmentService.GetDepartmentsAsync();
        if (depts != null)
        {
            Departments = depts;
            var dept = Departments.FirstOrDefault(d => d.Id == DepartmentId);
            if (dept != null)
            {
                Department = dept.Name;
            }
        }
    }

    private async Task SaveChangesAsync()
    {
        var updatedEmployee = new UpdateEmployeeDto
        {
            FirstName = FirstName.Trim(),
            LastName = LastName.Trim(),
            Email = Email.Trim(),
            Salary = Salary,
            DepartmentId = DepartmentId
        };

        var success = await _employeeService.UpdateEmployeeAsync((int)EmployeeId, updatedEmployee);
        if (success)
        {
            System.Windows.MessageBox.Show("Employee updated successfully.", "Success", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            RequestCloseWithSuccess?.Invoke();
        }
        else
        {
            System.Windows.MessageBox.Show("Failed to update employee.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }
    }

    private async Task DeleteEmployeeAsync()
    {
        var result = System.Windows.MessageBox.Show(
            "Are you sure you want to delete this employee?",
            "Confirm Delete",
            System.Windows.MessageBoxButton.YesNo,
            System.Windows.MessageBoxImage.Question);

        if (result != System.Windows.MessageBoxResult.Yes)
            return;

        var success = await _employeeService.DeleteEmployeeAsync((int)EmployeeId);
        if (success)
        {
            System.Windows.MessageBox.Show("Employee deleted successfully.", "Success", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            RequestCloseWithSuccess?.Invoke();
        }
        else
        {
            System.Windows.MessageBox.Show("Failed to delete employee.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }
    }
}