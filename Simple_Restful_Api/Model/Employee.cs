using System;
namespace Simple_Restful_Api.Model
{
    public class Employee
    {

        public int Id { get; set; }
        public int Age { get; set; }
        public string? Name { get; set; }
        public double Salary { get; set; }
        public Employee()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Employee employee &&
                   Id == employee.Id &&
                   Age == employee.Age &&
                   Name == employee.Name &&
                   Salary == employee.Salary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Age, Name, Salary);
        }
    }
}

