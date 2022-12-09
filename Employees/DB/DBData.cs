using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.DB
{
    public static class DBData
    {
        public static void AddTestData(ApiContext context)
        {
            var testUser1 = new DBModels.Employee
            {
                id = 1,
                name = "Václav",
                surname = "Novák",
                dateOfBirth = new DateTime(1985, 11, 5).ToString("d.MM.yyyy")
            };

            context.employees.Add(testUser1);

            context.SaveChanges();
        }


    }
}
