using Bussiness.Interface;
using Common.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bussiness.Services
{
    public class EmployeeBussiness : IEmployeeBussiness
    {


        public readonly IEmployeeRepository employeeRepository;

        public EmployeeBussiness(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public bool CreateEmployee(EmployeeModel model)
        {
            try
            {
              return  this.employeeRepository.CreateEmployee(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

      

        public IEnumerable<EmployeeModel> GetAllDataFromDataBase()
        {
            try
            {
                return this.employeeRepository.GetAllDataFromDataBase();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateDatafromDatabase(EmployeeModel model)
        {
            try
            {
                return this.employeeRepository.UpdateDatafromDatabase(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteDatafromDatabase(long EmpId)
        {
            try
            {
                return this.employeeRepository.DeleteDatafromDatabase(EmpId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
