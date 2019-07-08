using HandsOnExercise.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HandsOnExercise.DataAccessLayer
{
    public class DataSeeder
    {
        private const string ApiUri = "http://masglobaltestapi.azurewebsites.net/api/";
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Employees.Any())
            {
                List<DTOEmployee> employees = APIEmployee();
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get List of Employees from API
        /// </summary>
        /// <returns></returns>
        private static List<DTOEmployee> APIEmployee()
        {
            List<DTOEmployee> employees = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUri);

                var responseTask = client.GetAsync("Employees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<DTOEmployee>>();
                    readTask.Wait();

                    employees = readTask.Result;
                }
                else
                {
                    employees = new List<DTOEmployee>();
                }
            }
            return employees;
        }

        /// <summary>
        /// Create a List of Employee from Dummy Data
        /// </summary>
        /// <returns></returns>
        private static List<DTOEmployee> DummyEmployee()
        {
            List<DTOEmployee> employees = new List<DTOEmployee>()
                            {
                            new DTOEmployee { name = "kevin", contractTypeName="HourlySalaryEmployee", hourlySalary = 60000, monthlySalary = 80000  },
                            new DTOEmployee { name = "dario", contractTypeName="MonthlySalaryEmployee", hourlySalary = 60000, monthlySalary = 80000  },
                            };
            return employees;
        }

    }
}
