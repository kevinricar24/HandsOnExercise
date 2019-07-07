using HandsOnExercise.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HandsOnExercise.DataAccessLayer
{
    public class DataSeeder
    {

        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Employees.Any())
            {
                List<DTOEmployee> employees = null;
                //Dummy Data
                //var employees = new List<DTOEmployee>()
                //                {
                //                new DTOEmployee { name = "kevin", contractTypeName="HourlySalaryEmployee", hourlySalary = 60000, monthlySalary = 80000  },
                //                new DTOEmployee { name = "dario", contractTypeName="MonthlySalaryEmployee", hourlySalary = 60000, monthlySalary = 80000  },
                //                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/");

                    //HTTP GET
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

                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }

    }
}
