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

            DateTime startDate = new DateTime(2021, 01, 02);
            DateTime endDate = new DateTime(2021, 01, 27);
            employeeRepo.RetrieveEmployeesFromGivenDate(employeePayroll, startDate, endDate);
        }
    }
}
