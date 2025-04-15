using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Context
{
    public class EmployeeContext : DbContext
    {
        /// <summary>
        /// Table Name: Employees
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=Employee.db");
    }
}
