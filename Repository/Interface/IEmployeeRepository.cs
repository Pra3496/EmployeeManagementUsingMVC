using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IEmployeeRepository
    {
        public bool CreateEmployee(EmployeeModel model);

        public IEnumerable<EmployeeModel> GetAllDataFromDataBase();

        public bool UpdateDatafromDatabase(EmployeeModel model);

        public bool DeleteDatafromDatabase(long EmpId);
    }
}
