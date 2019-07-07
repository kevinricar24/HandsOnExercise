namespace HandsOnExercise.BusinessLogic.Factory
{
    class HourlySalaryEmployee : ICalcSalary
    {
        public decimal CalcSalary(decimal hourlySalary, decimal monthlySalary)
        {
            return 120 * hourlySalary * 12;
        }
    }
}
