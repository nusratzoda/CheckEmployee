using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeServices _employeeServices;
    public EmployeeController(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }
    [HttpGet]
    public async Task<List<GetEmployeeDto>> GetEmployees()
    {
        return await _employeeServices.GetEmployees();
    }
    [HttpPost]
    public async Task<AddEmployeeDto> AddEmployee(AddEmployeeDto employeeDto)
    {
        return await _employeeServices.AddCustomer(employeeDto);
    }
    [HttpPut]
    public async Task<AddEmployeeDto> UpdateEmployee(AddEmployeeDto employeeDto)
    {
        return await _employeeServices.UpdateEmployee(employeeDto);
    }
    [HttpDelete]
    public async Task<bool> DeleteEmployee(int id)
    {
        return await _employeeServices.DeleteEmployee(id);
    }
}
