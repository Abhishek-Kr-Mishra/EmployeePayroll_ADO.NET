using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeRepo
    {
        public static string connectionString = "Server=(Localdb)\\MSSQLLocalDB;database=Payroll_Service;Trusted_Connection=true";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        //SqlCommand command;
        public DataSet GetAllEmployee()
        {
            //command = new SqlCommand("sp_ReadDataFromEmployeePayrollTable", sqlConnection);
            try
            {
                DataSet dataSet = new DataSet();
                using(this.sqlConnection)
                {
                    this.sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("sp_ReadDataFromEmployeePayrollTable", sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                    this.sqlConnection.Close();
                    return dataSet;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
