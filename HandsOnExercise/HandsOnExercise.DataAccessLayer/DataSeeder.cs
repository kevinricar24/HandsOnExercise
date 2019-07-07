using HandsOnExercise.BusinessLogic;
using System.Collections.Generic;
using System.Linq;

namespace HandsOnExercise.DataAccessLayer
{
    public class DataSeeder
    {

        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Employees.Any())
            {
                var employees = new List<DTOEmployee>()
                                {
                                new DTOEmployee { name = "kevin", contractTypeName="HourlySalaryEmployee", hourlySalary = 60000, monthlySalary = 80000  },
                                new DTOEmployee { name = "dario", contractTypeName="MonthlySalaryEmployee", hourlySalary = 60000, monthlySalary = 80000  },
                                };
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }

    }
}
