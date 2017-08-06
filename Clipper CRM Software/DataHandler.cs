using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clipper_CRM_Software
{
    public class DataHandler
    {
        private List<string> Name = new List<string>();
        private Dictionary<string, string> empNamePosition = new Dictionary<string, string>();
        private Dictionary<string, string> empSalaryRate = new Dictionary<string, string>();
        private Dictionary<int, string> empNameID = new Dictionary<int, string>();
        private Dictionary<int, string> supplierNameID = new Dictionary<int, string>();
        public void SetJsonData(string jsonEmployeeData, string jsonEmployeeRoleData,string jsonEmployeeSalaryData,string jsonSupplierData)
        {
            ParseJsonEmployeeData(jsonEmployeeData);
            ParseJsonEmployeeRoleData(jsonEmployeeRoleData, jsonEmployeeSalaryData);
            //  ParseJsonEmployeeRoleData(jsonEmployeeSalaryData);
            ParseJsonSupplierData(jsonSupplierData);
        }

        private void ParseJsonEmployeeRoleData(string jsonRoleData,string jsonSalaryData)
        {
            var roleResult = JsonConvert.DeserializeObject<List<EmployeeRole>>(jsonRoleData);
            var salaryResult = JsonConvert.DeserializeObject<List<EmployeeSalary>>(jsonSalaryData);
            foreach (var employeeRole in roleResult)
            {
                var SalaryRatebyID= salaryResult.FirstOrDefault(o => o.RoleID == employeeRole.RoleId);               
                string role = Regex.Replace(employeeRole.RoleName, @"\s+", "");
                string rate ;
                if (SalaryRatebyID==null)
                {
                    rate = "0.0";
                }
                else
                {
                    rate = SalaryRatebyID.BasicSalary.ToString();
                }
                empSalaryRate.Add(role, rate);

            }
        }

        private void ParseJsonEmployeeData(string jsonData)
        {
            var result = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
            foreach (var employee in result)
            {
                var firstNames = employee.FirstName;
                var lastNames = employee.LastName;
                var position = employee.EmpRole;
                string name = firstNames + " " + lastNames;
                empNamePosition.Add(name, position);
                empNameID.Add(employee.EmpID, name);
            }

        }
        private void ParseJsonSupplierData(string jsonData)
        {
            var result = JsonConvert.DeserializeObject<List<SupplierName>>(jsonData);
            foreach (var supplier in result)
            {
                var supplierNames = supplier.Name;
                var lastNamsupplierID = supplier.SupplierID;     
                supplierNameID.Add(supplier.SupplierID, supplier.Name);
            }
        }
        public Dictionary<string, string> GetEmployeeName()
        {
            return empNamePosition;
        }
        public Dictionary<string, string> GetEmployeeSalaryRate()
        {
            return empSalaryRate;
        }

        public Dictionary<int,string> GetEmployeeID()
        {
            return empNameID;
        }
        public Dictionary<int, string> GetSupplierNameID()
        {
            return supplierNameID;
        }
    }
}
