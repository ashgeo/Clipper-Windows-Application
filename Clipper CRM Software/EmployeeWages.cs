using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipper_CRM_Software
{
    class EmployeeWages
    {
        public int PayID { get;set;}
        public DateTime PayDate { get; set; }
        public string EmpName { get; set; }
        public string Role { get; set; }       
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public double TotalHours { get; set; }
        public double TotalAmount { get; set; }
        public double TotalPaid { get; set; }
        public bool IsPaid { get; set; }
        public double PayDue { get; set; }
        public int EmpID { get; internal set; }


    }
    
}
