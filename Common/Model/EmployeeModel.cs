using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common.Model
{
    public class EmployeeModel
    {

        public long EmpId { get; set; } 
        public string Name { get; set; }

        public string ProfileImg { get; set; }

        public string Gender { get; set; }

        public string Department { get; set; }

        public decimal Salary { get; set; }

        public DateTime StartDate { get; set; }

        public string Notes { get; set; }



    }
}
