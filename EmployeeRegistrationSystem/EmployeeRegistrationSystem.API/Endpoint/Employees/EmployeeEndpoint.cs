using EmployeeRegistrationSystem.API.Common;
using EmployeeRegistrationSystem.API.Communication.Request;
using EmployeeRegistrationSystem.API.Domain.Entities;
using EmployeeRegistrationSystem.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EmployeeRegistrationSystem.API.Endpoint.Employees
{
    public class EmployeeEndpoint : IEndpoint
    {
        private static EmployeeRegistrationSystemDbContext _dbContext = null!;

        public static void Map(IEndpointRouteBuilder app)
        {
            _dbContext ??= new EmployeeRegistrationSystemDbContext();

            app.MapPost("/", HandleEmployeePostAsync);
            app.MapGet("/{id}", HandleEmployeeGetByIdAsync);
            app.MapPut("/{id}", HandleEmployeePutAsync);
            app.MapDelete("/{id}", HandleEmployeeDeleteByIdAsync);
        }

        private static async Task<IResult> HandleEmployeeDeleteByIdAsync([FromRoute] Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee is null)
            {
                return Results.NotFound();
            }

            employee.IsDeleted = true;

            await _dbContext.SaveChangesAsync();

            await AddEmployeeLogs(employee, ActionType.Removal);

            return Results.Ok();
        }

        private static async Task<IResult> HandleEmployeePutAsync([FromRoute] Guid id, EmployeeJson employeeJson)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee is null)
            {
                return Results.NotFound();
            }

            employee.Name = employeeJson.Name;
            employee.Address = employeeJson.Address;
            employee.ProfessionalEmail = employeeJson.ProfessionalEmail;
            employee.Salary = employeeJson.Salary;
            employee.AdmissionDate = employeeJson.AdmissionDate;

            await _dbContext.SaveChangesAsync();

            await AddEmployeeLogs(employee, ActionType.Update);

            return Results.Ok();
        }

        private static async Task<IResult> HandleEmployeeGetByIdAsync([FromRoute] Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == id);

            if (employee is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(employee);
        }

        private static async Task<IResult> HandleEmployeePostAsync([FromBody] EmployeeJson employeeJson)
        {
            var newEmployee = new Employee
            {
                Name = employeeJson.Name,
                Address = employeeJson.Address,
                ProfessionalEmail = employeeJson.ProfessionalEmail,
                Salary = employeeJson.Salary,
                AdmissionDate = employeeJson.AdmissionDate
            };

            _dbContext.Employees.Add(newEmployee);
            await _dbContext.SaveChangesAsync();

            await AddEmployeeLogs(newEmployee, ActionType.Inclusion);

            return Results.Ok();
        }

        private static async Task AddEmployeeLogs(Employee employee, ActionType actionType)
        {
            var newEmployeeLog = new EmployeeLog
            {
                ActionType = actionType,
                JSON = JsonSerializer.Serialize(employee),
                PartitionKey = "TI",
                RowKey = Guid.NewGuid().ToString(),
                Timestamp = DateTimeOffset.Now,
                EmployeeId = employee.Id
            };

            _dbContext.EmployeeLogs.Add(newEmployeeLog);
            await _dbContext.SaveChangesAsync();
        }
    }
}
