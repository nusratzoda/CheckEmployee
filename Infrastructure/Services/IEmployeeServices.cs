using Domain.Dtos;

namespace Infrastructure.Services;

public interface IEmployeeServices
{
    Task<AddEmployeeDto> AddCustomer(AddEmployeeDto employeeDto);
    Task<AddEmployeeDto> GetEmployeeById(int id);
    Task<List<GetEmployeeDto>> GetEmployees();
    Task<AddEmployeeDto> UpdateEmployee(AddEmployeeDto employeeDto);
    Task<bool> DeleteEmployee(int id);
}
