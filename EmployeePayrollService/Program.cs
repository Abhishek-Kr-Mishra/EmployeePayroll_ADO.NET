using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();

            employeeRepo.GetAllEmployee();
        }
    }
}
