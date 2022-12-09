using System;

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

            var testUser2 = new DBModels.Employee
            {
                id = 2,
                name = "Adam",
                surname = "Kopeček",
                dateOfBirth = new DateTime(1995, 11, 5).ToString("d.MM.yyyy")
            };

            var testUser3 = new DBModels.Employee
            {
                id = 3,
                name = "Jaromír",
                surname = "Woronycz",
                dateOfBirth = new DateTime(2000, 11, 5).ToString("d.MM.yyyy")
            };

            context.employees.Add(testUser1);
            context.employees.Add(testUser2);
            context.employees.Add(testUser3);

            context.SaveChanges();
        }
    }
}
