//https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1
//https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1

using System.Collections.Generic;
using System.Threading.Tasks;
using DLL.DBContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> InsertAsync(Department department);
        
        Task<List<Department>> GetAllAsync();

        Task<Department> DeleteAsync(string code);

        Task<Department> GetAAsync(string code);

        Task<Department> UpdateAsync(string code, Department department);
        Task<Department> FindByName(string name);
        Task<Department> FindByCode(string code);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> InsertAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> DeleteAsync(string code)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> GetAAsync(string code)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);
            return department;
        }
        
        public async Task<Department> UpdateAsync(string code, Department department)
        {
            var findDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);
            findDepartment.Name = department.Name;
            _context.Departments.Update(findDepartment);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> FindByName(string name)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Department> FindByCode(string code)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);
        }
    }
}