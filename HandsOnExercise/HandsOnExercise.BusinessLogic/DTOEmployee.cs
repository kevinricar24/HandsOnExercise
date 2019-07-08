using HandsOnExercise.BusinessLogic.Factory;

namespace HandsOnExercise.BusinessLogic
{
    public class DTOEmployee : Employee
    {
        public decimal salary
        {
            get
            {
                decimal response = 0;
                if (!string.IsNullOrEmpty(contractTypeName))
                {
                    response = CalculationSalary(contractTypeName, hourlySalary, monthlySalary);
                }
                return response;
            }
        }

        public decimal CalculationSalary(string paramContractTypeName, decimal paramHourlySalary, decimal paramMonthlySalary)
        {
            EmployeeSalary employeeSalary = new ConcreteEmployeeSalary();
            ICalcSalary salary = employeeSalary.Salary(paramContractTypeName);
            return salary.CalcSalary(paramHourlySalary, paramMonthlySalary);
        }

    }
}
