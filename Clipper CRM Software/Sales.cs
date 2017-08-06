using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipper_CRM_Software
{
    class Sales
    {
        public int SaleID { get; set; }
        public string Date { get; set; }
        public decimal FtposAmount { get; set; }
        public decimal CashAmount { get; set; }
        public decimal TotalSale { get; set; }
        public decimal BlueBoxAmount { get; set; }
        public decimal CashLeft { get; set; }
        public double OtherExpense { get; internal set; }
        public decimal CashTakenFromPreviousDay { get; internal set; }
    }
}
