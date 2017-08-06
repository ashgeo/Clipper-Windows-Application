using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipper_CRM_Software
{
    class SalesExpense
    {
        public int SalesExpenseID { get; set; }
        public System.DateTime Date { get; set; }
        public decimal TotalFTPOSAmount { get; set; }
        public decimal SupplierAmountPaid { get; set; }
        public decimal EmployeeAmountPaid { get; set; }
        public decimal CashLeftToday { get; set; }
        public decimal TotalExpence { get; set; }
        public decimal TotalTillSale { get; set; }
        public decimal CashTakenFromPreviousSale { get; set; }
        public decimal TotalCashLeft { get; set; }        
    }
}
