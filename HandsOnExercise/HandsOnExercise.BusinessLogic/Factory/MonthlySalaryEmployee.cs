namespace HandsOnExercise.BusinessLogic.Factory
{
    class MonthlySalaryEmployee : ICalcSalary
    {
        public decimal CalcSalary(decimal hourlySalary, decimal monthlySalary)
        {
            return monthlySalary * 12;
        }
    }
}
