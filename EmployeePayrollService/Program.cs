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
            //string gender = "Male";

            employeePayroll.EmpName = "Mohan";
            employeePayroll.StartDate = new DateTime(2021, 01, 28);
            employeePayroll.Gender = "Male";
            employeePayroll.PhoneNumber = 8927841235;
            employeePayroll.Address = "SriNagar";
            employeePayroll.DeptID = 3;
            payroll.BasicPay = 360000;
            payroll.Deduction = 24000;
            payroll.TaxablePay = 6000;
            payroll.IncomeTax = 12000;
            payroll.NetPay = 26500;

            employeeRepo.AddEmployee(employeePayroll, payroll);

            //DateTime startDate = new DateTime(2021, 01, 02);
            //DateTime endDate = new DateTime(2021, 01, 27);
            //employeeRepo.RetrieveEmployeesFromGivenDate(employeePayroll, startDate, endDate);

            //employeeRepo.GetTheMaxmumValueOfNetPayByGender(payroll, gender);
            //employeeRepo.GetTheAverageOfNetPayByGender(payroll, gender);
            //employeeRepo.GetTheMinimumValueOfNetPayByGender(payroll, gender);
            //employeeRepo.GetTheSumOfNetPayByGender(payroll, gender);
        }
    }
}
