using Common.Model;
using Microsoft.Extensions.Configuration;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly IConfiguration Iconfiguration;

        public readonly string connectionString;

        public EmployeeRepository(IConfiguration Iconfiguration)
        {
            this.Iconfiguration = Iconfiguration;

            this.connectionString = this.Iconfiguration.GetConnectionString("EmployeeDB");
        }

       // public string connectionString = @"data source=.;initial catalog=EmployeeManegmentDB;trusted_connection=True;TrustServerCertificate=True";

        public bool CreateEmployee(EmployeeModel model)
        {
            bool flags;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spAddingNewDataToEmpDB", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;


                    sqlCommand.Parameters.AddWithValue("@Name", model.Name);
                    sqlCommand.Parameters.AddWithValue("@ProfileImg", model.ProfileImg);
                    sqlCommand.Parameters.AddWithValue("@Gender", model.Gender);
                    sqlCommand.Parameters.AddWithValue("@Department", model.Department);
                    sqlCommand.Parameters.AddWithValue("@Salary", model.Salary);
                    sqlCommand.Parameters.AddWithValue("@StartDate", model.StartDate);
                    sqlCommand.Parameters.AddWithValue("@Notes", model.Notes);

                    int result = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();

                    if (result >= 1)
                    {
                        flags = true;
                    }
                    else { flags = false; }
                }

                if (flags == true)
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public IEnumerable<EmployeeModel> GetAllDataFromDataBase()
        {
           
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<EmployeeModel> EmployeeList = new List<EmployeeModel>();

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spRetriveDataOfEmp", sqlConnection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            EmployeeModel model = new EmployeeModel();
                            model.EmpId = sqlReader.GetInt64(0);
                            model.Name = sqlReader.GetString(1);
                            model.ProfileImg = sqlReader.GetString(2);
                            model.Gender = sqlReader.GetString(3);
                            model.Department = sqlReader.GetString(4);
                            model.Salary = sqlReader.GetDecimal(5);
                            model.StartDate = sqlReader.GetDateTime(6);
                            model.Notes = sqlReader.GetString(7);


                            EmployeeList.Add(model);
                        }

                        return EmployeeList;


                    }
                    else
                    { return null; }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool UpdateDatafromDatabase(EmployeeModel model)
        {
            bool flags = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
        
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spUpdateEmployeeDeatils", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmpId", model.EmpId);
                    sqlCommand.Parameters.AddWithValue("@Name", model.Name);
                    sqlCommand.Parameters.AddWithValue("@ProfileImg", model.ProfileImg);
                    sqlCommand.Parameters.AddWithValue("@Gender", model.Gender);
                    sqlCommand.Parameters.AddWithValue("@Department", model.Department);
                    sqlCommand.Parameters.AddWithValue("@Salary", model.Salary);
                    sqlCommand.Parameters.AddWithValue("@StartDate", model.StartDate);
                    sqlCommand.Parameters.AddWithValue("@Notes", model.Notes);
                    int result = sqlCommand.ExecuteNonQuery();


                    if (result >= 1)
                    {
                        flags = true;
                    }
                    else { flags = false; }


                }

                if (flags == true)
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                sqlConnection.Close();
            }


        }

        public bool DeleteDatafromDatabase(long EmpId)
        {
            bool flags = false;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spDeleteEmployeeDeatils", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmpId", EmpId);
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result >= 1)
                    {
                        flags = true;
                    }
                    else { flags = false; }
                }

                if (flags == true)
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
