using System;
using Simple_Restful_Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Simple_Restful_Api.Controllers

{
    [ApiController]
    public class ManagerController : ControllerBase
    {

        public Manager manager { get; set; }
        public ManagerController()
        {
            manager = new Manager();
            manager.superviees.Add(new Employee { Id = 1, Age = 22,Name="qingyang",Salary=12000});
            manager.superviees.Add(new Employee { Id = 2, Age = 23, Name = "Andy", Salary = 11000 });
            manager.superviees.Add(new Employee { Id = 3, Age = 24, Name = "Sam", Salary = 10000 });
            manager.superviees.Add(new Employee { Id = 4, Age = 21, Name = "mike", Salary = 13000 });
        }

        [HttpGet]
        [Route("/getEmployeeById")]
        public Employee? getEmployeeId(int id)
        {
            return manager.FindEmpolyeeById(id);
        }

        [HttpGet]
        [Route("/getOldestEmpolyee")]
        public Employee? getOldestEmployee()
        {
            return manager.FindOldestEmployee();
        }

        [HttpGet]
        [Route("/getBiggestSalaryEmployee")]
        public Employee? getBiggestSalaryEmployee()
        {
            return manager.FindBiggestSalaryEmployee();
        }
    }
}

