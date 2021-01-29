using EmployeePayrollService;
using EmployeePayrollService.Model.PayrollModel;
using NUnit.Framework;

namespace EmployeePayrollService_NUnitTest
{
    public class EmployeePayrollTest
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();
        EmployeePayroll employeePayroll = new EmployeePayroll();
        PayrollDetailModel payroll = new PayrollDetailModel();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenPayrollToUpdate_WhenDataIsPresentInTable_ShouldReturnTrue()
        {

            payroll.BasicPay = 30000;
            employeePayroll.EmpID = 8;
            employeePayroll.EmpName = "Terisa";
            employeePayroll.StartDate = new System.DateTime(2021, 01, 27);
            employeePayroll.Gender = "Female";
            employeePayroll.PhoneNumber = 7559171697;
            employeePayroll.Address = "Mumbai";
            employeePayroll.DeptID = 1;
            bool actual = employeeRepo.UpdateEmpoyeeSalaryData(employeePayroll, payroll);

            Assert.IsTrue(actual);
        }

        [Test]
        public void GivenEmployeeDataToInsert_WhenDataIsPresentInTable_ShouldReturnTrue()
        {
            employeePayroll.EmpName = "Mohan";
            employeePayroll.StartDate = new System.DateTime(2021, 01, 29);
            employeePayroll.Gender = "Male";
            employeePayroll.PhoneNumber = 9804567321;
            employeePayroll.Address = "Bengaluru";
            employeePayroll.DeptID = 3;

            bool actual = employeeRepo.AddEmployee(employeePayroll);
            Assert.IsTrue(actual);
        }
    }
}