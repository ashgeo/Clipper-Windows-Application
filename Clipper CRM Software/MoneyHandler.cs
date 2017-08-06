using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipper_CRM_Software{
    
    class MoneyHandler
    {
        private  string Role { get; set; }
        private double totalSalary { get; set; }
       

        internal double CalculateSalary(string role, double totalHoursWorked, Dictionary<string, string> salaryRate)
        {
            double rate = 0;
            
            if (Roles.CEO.ToString()== role)
            {
                rate = Convert.ToDouble(salaryRate[role]);
                totalSalary = totalHoursWorked * rate;
            }
            else if (Roles.Manager.ToString() == role)
            {
                rate = Convert.ToDouble(salaryRate[role]);
                totalSalary = totalHoursWorked * rate;
            }
            else if (Roles.Coffe_Maker.ToString() == role)
            {
                rate = Convert.ToDouble(salaryRate[role]);
                totalSalary = totalHoursWorked * rate;

            }
            else if (Roles.Cook.ToString() == role)
            {
                rate = Convert.ToDouble(salaryRate[role]);
                totalSalary = totalHoursWorked * rate;

            }
            else if (Roles.Chef.ToString() == role)
            {
                rate = Convert.ToDouble(salaryRate[role]);
                totalSalary = totalHoursWorked * rate;

            }
            else if (Roles.Waitress.ToString() == role)
            {
                rate = Convert.ToDouble(salaryRate[role]);
                totalSalary = totalHoursWorked * rate;
            }
            else if (Roles.KHand.ToString() == role)
            {
                rate = Convert.ToDouble(salaryRate[role]);
                totalSalary = totalHoursWorked * rate;
            }
            return totalSalary;
        }

        internal double CalculateTotalHours( DateTime startTime, DateTime endTime)
        {           
            TimeSpan ts =  endTime- startTime;
           
            double totalHours = ts.TotalHours;
            if(totalHours<0)
            {
                totalHours = 0;
            }
            return totalHours;
        }
    }
}
