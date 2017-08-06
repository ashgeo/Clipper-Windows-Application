using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipper_CRM_Software
{
    class EmployeeSalary
    {

        public int RoleID { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal SalaryRateMF { get; set; }
        public decimal SalaryRateSat { get; set; }
        public decimal SalaryRateSun { get; set; }
        public decimal SalaryRatePH { get; set; }       
    }
}
