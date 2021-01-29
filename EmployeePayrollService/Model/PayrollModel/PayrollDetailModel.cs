using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService.Model.PayrollModel
{
    public class PayrollDetailModel
    {
        public int PayrollID { get; set; }
        public double BasicPay { get; set; }
        public double Deduction { get; set; }
        public double IncomeTax { get; set; }
        public double TaxablePay { get; set; }
        public decimal NetPay { get; set; }
        public int EmpID { get; set; }
    }
}
