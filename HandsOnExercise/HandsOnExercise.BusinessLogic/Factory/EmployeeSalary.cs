namespace HandsOnExercise.BusinessLogic.Factory
{
    abstract class EmployeeSalary
    {
        public abstract ICalcSalary Salary(string employeeType);
    }
}
