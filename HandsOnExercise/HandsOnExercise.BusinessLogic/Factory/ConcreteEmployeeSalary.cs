namespace HandsOnExercise.BusinessLogic.Factory
{
    class ConcreteEmployeeSalary : EmployeeSalary
    {
        public override ICalcSalary Salary(string employeeType)
        {
            switch (employeeType)
            {
                case "MonthlySalaryEmployee":
                    return new MonthlySalaryEmployee();
                case "HourlySalaryEmployee":
                    return new HourlySalaryEmployee();
                default:
                    return new HourlySalaryEmployee();
            }
        }
    }
}
