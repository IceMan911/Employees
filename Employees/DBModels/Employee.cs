using System;

namespace Employees.DBModels
{
    public class Employee
    {
        public uint id { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public DateTime dateOfBirth  { get; set; }
    }
}
