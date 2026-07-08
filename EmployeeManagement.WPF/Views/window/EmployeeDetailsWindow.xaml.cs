using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.WPF.Services;
using EmployeeManagement.WPF.ViewModels.Windows;
using System.Windows;

namespace EmployeeManagement.WPF.Views.Windows;

public partial class EmployeeDetailsWindow : Window
{
    public EmployeeDetailsWindow(EmployeeDto employee, DepartmentService departmentService, EmployeeService employeeService)
    {
        InitializeComponent();

        var vm = new EmployeeDetailsViewModel(employee, departmentService, employeeService);

        vm.RequestClose += OnRequestClose;
        vm.RequestCloseWithSuccess += OnRequestCloseWithSuccess;

        DataContext = vm;

        Loaded += async (sender, e) =>
        {
            await vm.LoadDepartmentsAsync();
        };
    }

    private void OnRequestClose()
    {
        DialogResult = false;
        Close();
    }

    private void OnRequestCloseWithSuccess()
    {
        DialogResult = true;
        Close();
    }
}