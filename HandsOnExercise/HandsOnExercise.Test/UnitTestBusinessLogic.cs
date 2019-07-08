using HandsOnExercise.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HandsOnExercise.Test
{
    [TestClass]
    public class UnitTestBusinessLogic
    {
        List<DTOEmployee> employees;

        public List<DTOEmployee> SetData()
        {
            return new List<DTOEmployee>()
            {
                new DTOEmployee()
                {
                    id = 1,
                    name = "Test Name1",
                    contractTypeName = "HourlySalaryEmployee",
                    roleId = 1,
                    roleName = "Administrator",
                    roleDescription = null,
                    hourlySalary = 60,
                    monthlySalary = 120,
                },
                 new DTOEmployee()
                {
                    id = 2,
                    name = "Test Name2",
                    contractTypeName = "MonthlySalaryEmployee",
                    roleId = 2,
                    roleName = "Contractor",
                    roleDescription = null,
                    hourlySalary = 60,
                    monthlySalary = 120,
                },
            };
        }

        [TestMethod]
        public void CalulateHourlySalaryEmployee()
        {
            employees = SetData();
            decimal expectedSalary = 86400;
            decimal resultSalary;

            resultSalary = employees[0].salary;

            Assert.AreEqual(expectedSalary, resultSalary);
        }

        [TestMethod]
        public void CalulateMonthlySalaryEmployee()
        {
            employees = SetData();
            decimal expectedSalary = 1440;
            decimal resultSalary;

            resultSalary = employees[1].salary;

            Assert.AreEqual(expectedSalary, resultSalary);
        }
    }
}
