using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.WPF.ViewModels.Windows;
using System.Windows;

namespace EmployeeManagement.WPF.Views.Windows;

public partial class EmployeeDetailsWindow : Window
{
    public EmployeeDetailsWindow(EmployeeDto employee)
    {
        InitializeComponent();

        //DataContext = new EmployeeDetailsViewModel(employee);
        var vm = new EmployeeDetailsViewModel(employee);

        vm.RequestClose += OnRequestClose;

        DataContext = vm;
    }

    //private void BtnClose_Click(object sender, RoutedEventArgs e)
    //{
    //    Close();
    //}
    private void OnRequestClose()
    {
        DialogResult = false;
        Close();
    }
}