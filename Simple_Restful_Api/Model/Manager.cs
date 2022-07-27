using System;
namespace Simple_Restful_Api.Model
{
    public class Manager : Employee, IManager
    {

        public List<Employee> superviees { get; set; }

        public Manager()
        {
            superviees = new List<Employee>();
        }

        public Employee? FindEmpolyeeById(int id)
        {
            foreach(Employee e in superviees)
            {
                if (e.Id == id) return e;
            }
            return null;
        }
        
        public Employee? FindOldestEmployee()
        {
            Employee res = superviees[0];

            foreach(Employee e in superviees)
            {
                if (e.Age > res.Age)
                {
                    res = e;
                }
            }

            return res;
        }

        public Employee? FindBiggestSalaryEmployee()
        {
            Employee res = superviees[0];
            foreach(Employee e in superviees)
            {
                if (e.Salary > res.Salary)
                {
                    res = e;
                }
            }

            return res;
        }
    }
}

