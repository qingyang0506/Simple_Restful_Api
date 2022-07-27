namespace Simple_RestFul_ApiUnitTest;
using Simple_Restful_Api.Model;
using Simple_Restful_Api.Controllers;
using NSubstitute;
using System;

public class Tests
{

    ManagerController MC;

    [SetUp]
    public void Setup()
    {
        MC = new ManagerController();
    }

    [Test]
    public void TestGetEmployeeById()
    {
        var manager = Substitute.For<IManager>();

        var id = 5;
        var name = "Jason";
        var age = 20;
        var Salary = 6200;

        var em = new Employee() { Id = id, Age = age, Name = name, Salary = Salary };
        MC.manager.superviees.Add(em);
        manager.FindEmpolyeeById(id).Returns(em);

        var res = manager.FindEmpolyeeById(id);

        Assert.That(res, Is.EqualTo(MC.manager.FindEmpolyeeById(id)));

    }

    [Test]
    public void TestGetOldestEmployee()
    {
        var manager = Substitute.For<IManager>();

        var oldest = new Employee() { Id = 3, Age = 24, Name = "Sam", Salary = 10000 };

        manager.FindOldestEmployee().Returns(oldest);

        Assert.That(manager.FindOldestEmployee(), Is.EqualTo(MC.manager.FindOldestEmployee()));
    }

    [Test]
    public void TestGetBiggestSalaryEmployee()
    {
        var manager = Substitute.For<IManager>();

        var BiggestSalary = new Employee() { Id = 4, Age = 21, Name = "mike", Salary = 13000 };

        manager.FindBiggestSalaryEmployee().Returns(BiggestSalary);

        Assert.That(manager.FindBiggestSalaryEmployee(), Is.EqualTo(MC.manager.FindBiggestSalaryEmployee()));
    }
}
