using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EmployeePayrollService.Model.PayrollModel;

namespace EmployeePayrollService
{
    class Payroll
    {
        private static SqlConnection ConnectionSetUp()
        {
            return new SqlConnection("Server=(Localdb)\\MSSQLLocalDB;database=Payroll_Service;Trusted_Connection=true");
        }
    }
}
