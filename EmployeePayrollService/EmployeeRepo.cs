using EmployeePayrollService.Model.PayrollModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = "Server=(Localdb)\\MSSQLLocalDB;database=Payroll_Service;Trusted_Connection=true";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        //SqlCommand command;
        public DataSet GetAllEmployee()
        {
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
        public bool UpdateEmpoyeeSalaryData(EmployeePayroll employeePayroll, PayrollDetailModel payroll)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_UpdateEmployeeData", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpID", employeePayroll.EmpID);
                command.Parameters.AddWithValue("@EmpName", employeePayroll.EmpName);
                command.Parameters.AddWithValue("@StartDay", employeePayroll.StartDate);
                command.Parameters.AddWithValue("@Gender", employeePayroll.Gender);
                command.Parameters.AddWithValue("@PhoneNumber", employeePayroll.PhoneNumber);
                command.Parameters.AddWithValue("@Address", employeePayroll.Address);
                command.Parameters.AddWithValue("@DeptID", employeePayroll.DeptID);
                command.Parameters.AddWithValue("@BasicPay", payroll.BasicPay);
                this.sqlConnection.Open();
                var result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                return false;
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
