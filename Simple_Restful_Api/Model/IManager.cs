using System;
namespace Simple_Restful_Api.Model
{
    public interface IManager
    {
        public Employee? FindEmpolyeeById(int id);
        public Employee? FindOldestEmployee();
        public Employee? FindBiggestSalaryEmployee();
    }
}

