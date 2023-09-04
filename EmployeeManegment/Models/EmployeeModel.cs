using System;

namespace EmployeeManegment.Models
{
    public class EmployeeModel
    {
        public string Name { get; set; }

        public string ProfileImg { get; set; }

        public string Gender { get; set; }

        public string Department { get; set; }

        public decimal Salary { get; set; }

        public DateTime StartDate { get; set; }

        public string Notes { get; set; }
    }
}
