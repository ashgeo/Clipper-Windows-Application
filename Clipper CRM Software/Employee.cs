using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipper_CRM_Software
{
    enum Roles {
        CEO,
        Manager,
        Cook,
        KHand,
        Waitress,
        Coffe_Maker,
        Chef,
    }
    

    class Employee
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmpRole { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
