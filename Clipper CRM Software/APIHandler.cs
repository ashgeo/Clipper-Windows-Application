using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Clipper_CRM_Software
{
    class APIHandler
    {
        static HttpClient client = new HttpClient();
        private string EmployeeData { get; set; }
        private string EmployeeRoleData { get; set; }
        private string EmployeeSalaryData { get; set; }
        private string SupplierData { get; set; }
        public APIHandler()
        {
            client.BaseAddress = new Uri("http://clipper-api.mavericktechlabs.com.au/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            RetriveEmployeeData();
            RetriveEmployeeRoleData();
            RetriveEmployeeSalaryData();
            RetriveSupplierData();

        }

        public async void RetriveEmployeeData()
        {
            string jsonString = string.Empty;
            HttpResponseMessage responseemp = client.GetAsync("api/employees/authorize").Result;
            if (responseemp.IsSuccessStatusCode)
            {
                EmployeeData = await responseemp.Content.ReadAsStringAsync();

            }
            else
            {
                // MessageBox.Show("Error Code" +
                //responseemp.StatusCode + " : Message - " + responseemp.ReasonPhrase);

            }
        }

        public async void RetriveSupplierData()
        {

            string jsonString = string.Empty;
            HttpResponseMessage responseemp = client.GetAsync("api/supplier/authorize").Result;
            if (responseemp.IsSuccessStatusCode)
            {
                SupplierData = await responseemp.Content.ReadAsStringAsync();
            }
            else
            {
                // MessageBox.Show("Error Code" +
                //responseemp.StatusCode + " : Message - " + responseemp.ReasonPhrase);
            }
        }


        public async void RetriveEmployeeRoleData()
        {
            string jsonString = string.Empty;
            HttpResponseMessage responseemp = client.GetAsync("api/employeerole/authorize").Result;
            if (responseemp.IsSuccessStatusCode)
            {
                EmployeeRoleData = await responseemp.Content.ReadAsStringAsync();

            }
            else
            { // MessageBox.Show("Error Code" +
              //responseemp.StatusCode + " : Message - " + responseemp.ReasonPhrase);
            }
        }


        public async void RetriveEmployeeSalaryData()
        {
            string jsonString = string.Empty;
            HttpResponseMessage responseemp = client.GetAsync("api/salary/authorize").Result;
            if (responseemp.IsSuccessStatusCode)
            {
                EmployeeSalaryData = await responseemp.Content.ReadAsStringAsync();

            }
            else
            {
                // MessageBox.Show("Error Code" +
                //responseemp.StatusCode + " : Message - " + responseemp.ReasonPhrase);

            }
        }
      
        public string GetEmployeeSalaryData()
        {
            return EmployeeSalaryData;
        }
        public void AddEmployeeWagesData(List<EmployeeWages> empWagesList)
        {           
                HttpResponseMessage responseemp = client.PostAsJsonAsync("api/employees/authorize/employee", empWagesList).Result;           
        }

        public void AddSalesWagesData(List<Sales> salesList)
        {           
              HttpResponseMessage responseemp = client.PostAsJsonAsync("api/sales/authorize/sales", salesList).Result;            
        }

        internal void AddSupplierData(List<Supplier> supplierList)
        {
            HttpResponseMessage responseemp = client.PostAsJsonAsync("api/supplier/authorize/supplierr", supplierList).Result;
        }
        public async void RetriveUserCreditintials()
        {

        }

        internal void AddSalesExpenseData(SalesExpense salesExpense)
        {
            HttpResponseMessage responseemp = client.PostAsJsonAsync("api/salesbalance/authorize/salesbalance", salesExpense).Result;
            Console.Write(responseemp.ToString());
        }


        public string GetEmployeeData()
        {
            return EmployeeData;
        }
        public string GetEmployeeRoleData()
        {
            return EmployeeRoleData;
        }
        public string GetSupplierData()
        {
            return SupplierData;
        }

    }
}
