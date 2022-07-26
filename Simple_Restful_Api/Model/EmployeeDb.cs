using System;
using Microsoft.EntityFrameworkCore;

namespace Simple_Restful_Api.Model
{
    public class EmployeeDb:DbContext
    {
        public EmployeeDb(DbContextOptions<EmployeeDb> options):base(options)
        {
        }

        public DbSet<Employee> Employees{ get; set; } = null!;
    }
}

