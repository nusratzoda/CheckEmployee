using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeServices : IEmployeeServices
{
    private readonly DataContext _context;
    public EmployeeServices(DataContext context)
    {
        _context = context;
    }

    public async Task<AddEmployeeDto> AddCustomer(AddEmployeeDto employeeDto)
    {
        var employee = new Employee
        {
            Id = employeeDto.Id,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Gender = employeeDto.Gender,
            Salary = employeeDto.Salary,
            FormerWork = employeeDto.FormerWork,
            BirthDate = employeeDto.BirthDate,
            Conditions = employeeDto.Conditions,
            Address = employeeDto.Address,
            Member = employeeDto.Member
        };

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        employeeDto.Id = employee.Id;


        var employeeCreated = await GetEmployeeById(employee.Id);
        return employeeCreated;
    }

    public async Task<AddEmployeeDto> GetEmployeeById(int id)
    {
        var emploee = await _context.Employees
            .Select(employeeDto => new AddEmployeeDto()
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Gender = employeeDto.Gender,
                Salary = employeeDto.Salary,
                FormerWork = employeeDto.FormerWork,
                BirthDate = employeeDto.BirthDate,
                Conditions = employeeDto.Conditions,
                Address = employeeDto.Address,
                Member = employeeDto.Member
            }).FirstOrDefaultAsync(tu => tu.Id == id);
        return emploee;
    }

    public async Task<List<GetEmployeeDto>> GetEmployees()
    {
        var emploee = await _context.Employees
            .Select(employeeDto => new GetEmployeeDto()
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Gender = employeeDto.Gender,
                Salary = employeeDto.Salary,
                FormerWork = employeeDto.FormerWork,
                BirthDate = employeeDto.BirthDate,
                Conditions = employeeDto.Conditions,
                Address = employeeDto.Address,
                Member = employeeDto.Member,
            }).ToListAsync();
        return emploee;
    }
    public async Task<AddEmployeeDto> UpdateEmployee(AddEmployeeDto employeeDto)
    {

        var employee = await _context.Employees.FirstOrDefaultAsync(em => em.Id == employeeDto.Id);

        if (employee == null)
        {
            return null;
        }

        employee.Id = employeeDto.Id;
        employee.FirstName = employeeDto.FirstName;
        employee.LastName = employeeDto.LastName;
        employee.Gender = employeeDto.Gender;
        employee.Salary = employeeDto.Salary;
        employee.FormerWork = employeeDto.FormerWork;
        employee.BirthDate = employeeDto.BirthDate;
        employee.Conditions = employeeDto.Conditions;
        employee.Address = employeeDto.Address;
        employee.Member = employeeDto.Member;

        await _context.SaveChangesAsync();

        var employeeUpdate = await GetEmployeeById(employee.Id);
        return employeeUpdate;
    }
    public async Task<bool> DeleteEmployee(int id)
    {
        var product = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

        if (product == null)
        {
            return false;
        }

        _context.Employees.Remove(product);
        await _context.SaveChangesAsync();

        return true;
    }
}
