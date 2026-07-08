using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.WPF.ViewModels.Base;
using System.Windows.Input;
using EmployeeManagement.WPF.Commands;

namespace EmployeeManagement.WPF.ViewModels.Windows;

public class EmployeeDetailsViewModel : ViewModelBase
{
    private string _firstName = string.Empty;
    public event Action? RequestClose;
    public ICommand CancelCommand { get; }
    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    private string _lastName = string.Empty;
    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

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

    public EmployeeDetailsViewModel(EmployeeDto employee)
    {
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        Email = employee.Email;
        Department = employee.DepartmentName;
        Salary = employee.Salary;
        EmployeeId = employee.Id;

        CancelCommand = new RelayCommand(_ =>
        {
            RequestClose?.Invoke();
        });
    }
}