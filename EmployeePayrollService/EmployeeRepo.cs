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
        public void RetrieveEmployeesFromGivenDate(EmployeePayroll employeePayroll, DateTime startDate, DateTime endDate)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_RetrieveEmployeesFromAParticularDate", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeePayroll.EmpID = reader.GetInt32(0);
                        employeePayroll.EmpName = reader.GetString(1);
                        employeePayroll.StartDate = reader.GetDateTime(2);
                        Console.WriteLine("{0}, {1}, {2} ", employeePayroll.EmpID, employeePayroll.EmpName, employeePayroll.StartDate);
                    }
                }
                else
                {
                    Console.WriteLine("No Data Found");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }

        }
        public void GetTheSumOfNetPayByGender(PayrollDetailModel payroll, string gender)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_SumOfEmployeeSalaryByGender", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Gender", gender);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        payroll.NetPay = reader.GetDecimal(0);
                        Console.WriteLine("Sum of " + gender + " Employee's NetPay is {0} ", payroll.NetPay);
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        public void GetTheAverageOfNetPayByGender(PayrollDetailModel payroll, string gender)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_AVGOfEmployeeSalaryByGender", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Gender", gender);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        payroll.NetPay = reader.GetDecimal(0);
                        Console.WriteLine("Average of " + gender + " Employee's NetPay is {0} ", payroll.NetPay);
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        public void GetTheMinimumValueOfNetPayByGender(PayrollDetailModel payroll, string gender)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_MINOfEmployeeSalaryByGender", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Gender", gender);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        payroll.NetPay = reader.GetDecimal(0);
                        Console.WriteLine("Minimin Netpay of " + gender + " Employee's NetPay is {0} ", payroll.NetPay);
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        public void GetTheMaxmumValueOfNetPayByGender(PayrollDetailModel payroll, string gender)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_MAXOfEmployeeSalaryByGender", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Gender", gender);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        payroll.NetPay = reader.GetDecimal(0);
                        Console.WriteLine("Maximum Netpay of " + gender + " Employee's NetPay is {0} ", payroll.NetPay);
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        public bool AddEmployee(EmployeePayroll employeePayroll,PayrollDetailModel payroll)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_AddEmployeeAndPayrollTogether", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpName", employeePayroll.EmpName);
                command.Parameters.AddWithValue("@StartDate", employeePayroll.StartDate);
                command.Parameters.AddWithValue("@Gender", employeePayroll.Gender);
                command.Parameters.AddWithValue("@PhoneNumber", employeePayroll.PhoneNumber);
                command.Parameters.AddWithValue("@Address", employeePayroll.Address);
                command.Parameters.AddWithValue("@DeptID", employeePayroll.DeptID);
                command.Parameters.AddWithValue("@BasicPay", payroll.BasicPay);
                command.Parameters.AddWithValue("@Deduction", payroll.Deduction);
                command.Parameters.AddWithValue("@TaxablePay", payroll.TaxablePay);
                command.Parameters.AddWithValue("@IncomeTax", payroll.IncomeTax);
                command.Parameters.AddWithValue("@NetPay", payroll.NetPay);
                this.sqlConnection.Open();
                var result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
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
