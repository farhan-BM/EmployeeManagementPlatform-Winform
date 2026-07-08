using EmployeeManagement.WinForms.Forms;
using EmployeeManagement.WinForms.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagement.WinForms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var builder = Host.CreateApplicationBuilder();

        builder.Configuration.AddJsonFile(
            "appsettings.json",
            optional: false,
            reloadOnChange: true);

        var baseUrl =
            builder.Configuration["ApiSettings:BaseUrl"]
            ?? throw new Exception("API Base URL not configured.");

        builder.Services.AddHttpClient<EmployeeService>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });

        builder.Services.AddHttpClient<DepartmentService>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });

        builder.Services.AddHttpClient("WpfDepartmentService", client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        }).AddTypedClient<EmployeeManagement.WPF.Services.DepartmentService>();

        builder.Services.AddHttpClient("WpfEmployeeService", client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        }).AddTypedClient<EmployeeManagement.WPF.Services.EmployeeService>();

        builder.Services.AddTransient<MainForm>();
        builder.Services.AddTransient<EmployeeForm>();

        using var host = builder.Build();

        var form = host.Services.GetRequiredService<MainForm>();

        Application.Run(form);
    }
}