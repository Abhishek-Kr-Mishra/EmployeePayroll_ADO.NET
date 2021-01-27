using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeRepo
    {
        public static string connectionString = @"Server=(Localdb)\\MSSQLLocalDB;database=Payroll_Service;Trusted_Connection=true";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand command;
    }
}
