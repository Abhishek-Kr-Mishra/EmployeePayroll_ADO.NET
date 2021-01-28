using EmployeePayrollService.Model.PayrollModel;
using System;
using System.Data;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeePayroll employeePayroll = new EmployeePayroll();
            PayrollDetailModel payroll = new PayrollDetailModel();
            string gender = "Male";
        }
        
    }
}
