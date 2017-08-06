using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipper_CRM_Software
{
    class Supplier
    {
        public int SupplierID { get; set; }
        public DateTime Date { get; set; }
        public string SupplierName { get; set; }
        public double chequeAmount { get; set; }
        public double TotalAmount { get; set; }
        public double AmountPaid { get; set; }
        public double AmountDue { get; set; }
    }
}
