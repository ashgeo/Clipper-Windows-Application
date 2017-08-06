using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clipper_CRM_Software
{
    public delegate void UpdateAmountDueTextDelegate(decimal due);
    public partial class ManagerPanel : Form
    {
        double totalSalaryPaidToday = 0;
        double totalSalaryDue = 0;
        double totalPosAmount = 0;
        double totalFtposAmount = 0;
        double totalSale = 0;
        double cashLeftToday = 0;
        double totalSupplierAmount = 0;
        double supplerAmountPaid = 0;
        double supplerChequeAmount = 0;
        double supplierAmountDue = 0;
        double otherExpense = 0;
        double cashFromPrevousDay = 0;
        string supplierName = "";

        static HttpClient client = new HttpClient();

        DataHandler dataHandler;
        DataBaseHandler dataBaseHandler;
        MoneyHandler moneyHandler;
        EmployeeWages employeeWages;
        APIHandler apiHandler;
        Sales sales;
        Supplier supplier;
        DataGridViewHandler dgHandler;
        Dictionary<string, string> EmployeeNameRole;
        Dictionary<int, string> SupplierNameID;
        List<string> empNameList;
        List<string> supplierNameList;
        List<EmployeeWages> employeeWagesList;
        List<Sales> salesList;
        List<string> empRoleList;
        public ManagerPanel()
        {
            EmployeeNameRole = new Dictionary<string, string>();
            SupplierNameID = new Dictionary<int, string>();
            empNameList = new List<string>();
            supplierNameList = new List<string>();
            apiHandler = new APIHandler();
            dataBaseHandler = new DataBaseHandler();
            moneyHandler = new MoneyHandler();
            dataHandler = new DataHandler();
            dgHandler = new DataGridViewHandler();
            empRoleList = new List<string>();
            employeeWagesList = new List<EmployeeWages>();
            employeeWages = new EmployeeWages();
            sales = new Sales();
            supplier = new Supplier();
            salesList = new List<Sales>();
            ListAllEmployees();
            InitializeComponent();
            initializeValues();
            ChangeDateTimePickerFormat();
            //txtSupplierAmount.TextChanged += TextChanged;



        }

        private void ChangeDateTimePickerFormat()
        {
            //dp_startTime.Format = DateTimePickerFormat.Time;
            //dp_startTime.ShowUpDown = true;
            //dp_endTime.Format = DateTimePickerFormat.Time;
            //dp_endTime.ShowUpDown = true;
        }

        private void initializeValues()
        {

            if (EmployeeNameRole != null)
            {
                EmployeeNameRole = dataHandler.GetEmployeeName();
                SupplierNameID = dataHandler.GetSupplierNameID();
                supplierNameList= SupplierNameID.Values.ToList();
                supplierNameList = SupplierNameID.Values.ToList();
                empNameList = EmployeeNameRole.Keys.ToList();
                empRoleList= EmployeeNameRole.Values.ToList();
                BindingSource bindingSourceEmpName = new BindingSource();
                BindingSource bindingSourceEmpRole = new BindingSource();
                BindingSource bindingSourceSupplierName = new BindingSource();
                bindingSourceEmpName.DataSource = empNameList;
                bindingSourceEmpRole.DataSource = empRoleList;                
                bindingSourceSupplierName.DataSource = supplierNameList;
                cb_supplierName.DataSource = bindingSourceSupplierName.DataSource;
                cb_empName.DataSource = bindingSourceEmpName.DataSource;
                cb_empPosition.DataSource = bindingSourceEmpRole.DataSource;
            }
            else
            {
                MessageBox.Show("Employee Record Not found");
            }
        }
        private void LoadControlValues()
        {

        }
        private void ListAllEmployees()
        {
            string jsonEmployeeData = apiHandler.GetEmployeeData();
            string jsonEmployeeRoleData = apiHandler.GetEmployeeRoleData();
            string jsonEmployeeSalaryData = apiHandler.GetEmployeeSalaryData();
            string jsonSupplierData = apiHandler.GetSupplierData();
            dataHandler.SetJsonData(jsonEmployeeData, jsonEmployeeRoleData, jsonEmployeeSalaryData, jsonSupplierData);
        }


        private void EmpNameChanged(object sender, EventArgs e)
        {
            if (EmployeeNameRole != null)
            {
                foreach (string empName in EmployeeNameRole.Keys)
                {
                    if (cb_empName.Text == empName)
                    {
                        cb_empPosition.Text = EmployeeNameRole[empName];
                    }
                }

            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var date = dp_dateToday.Value;
            string empname = cb_empName.Text;
            string role = cb_empPosition.Text;
            role = Regex.Replace(role, @"\s+", "");
            var startTime = Convert.ToDateTime("00:00:00");
            var endTime = Convert.ToDateTime("00:00:00");
            double calculatedSalary = Convert.ToDouble(txt_totalAmount.Text);
            double salaryPaidToday = Convert.ToDouble(txtSalaryPaid.Text);
            double checkdue = calculatedSalary - Convert.ToDouble(txtSalaryPaid.Text);
            if (checkdue == Convert.ToDouble(txtSalaryDue.Text))
            {             
                double calculatedTotalHours = Convert.ToDouble(txt_totalHours.Text);
                Dictionary<string, string> empSalaryRate = dataHandler.GetEmployeeSalaryRate();

                double salaryDue = Convert.ToDouble(txtSalaryDue.Text);

                int empID = GetEmpoloyeeID(empname);
                CreateEmployeeWages(empID, date, empname, role, startTime, endTime, calculatedTotalHours, calculatedSalary, salaryDue , salaryPaidToday);
                if (employeeWages != null)
                {
                    bool rowexist = false;
                    foreach (DataGridViewRow row in dg_employeeWages.Rows)
                    {
                        if (row.Cells[0].Value != null && empID.ToString() == row.Cells[0].Value.ToString())
                        {
                            rowexist = true;
                            MessageBox.Show("Record already exist in the table");
                            dgHandler.EditEmployeeGV(dg_employeeWages, employeeWages);
                            break;
                        }

                    }
                    if (!rowexist)
                    {
                        dgHandler.AddEmployeeGV(dg_employeeWages, employeeWages);
                        dg_employeeWages.RefreshEdit();
                        dg_employeeWages.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Salary due do not match with your entered data");
            }

        }

        private void EditEmployeeWagesGV(int empID, EmployeeWages employeeWagesReceived)
        {
            employeeWages = employeeWagesReceived;
            employeeWages.EmpID = empID;
        }

        private void CreateEmployeeWages(int empID, DateTime date, string empname, string role, DateTime startTime, DateTime endTime, double calculatedTotalHours, double calculatedSalary, double salaryDue ,double salaryPaid)
        {
            employeeWages.EmpID = empID;
            employeeWages.PayDate = date;
            employeeWages.EmpName = empname;
            employeeWages.Role = role;
            employeeWages.StartTime = startTime;
            employeeWages.FinishTime = endTime;
            employeeWages.TotalHours = calculatedTotalHours;
            employeeWages.TotalAmount = calculatedSalary;
            employeeWages.TotalPaid = salaryPaid;
            employeeWages.PayDue = salaryDue;
            employeeWagesList.Add(employeeWages);
        }

        private int GetEmpoloyeeID(string empName)
        {
            Dictionary<int, string> employeeID = dataHandler.GetEmployeeID();
            var empId = employeeID.FirstOrDefault(x => x.Value.Contains(empName)).Key;
            return empId;
        }     

        private void btn_empRecordSubmit_Click(object sender, EventArgs e)
        {
            ClearEmployeeDataFromGV();
            GetSalaryDetailsFromDView();
            CalculateExpenseAndSales();
          
        }

        private void btnsSalesToDB_Click(object sender, EventArgs e)
        {
            ClearSalesDataFromGV();
            GetSalesDetailsFromDView();
            CalculateExpenseAndSales();

        }
      
        private void btn_supplier_Click(object sender, EventArgs e)
        {
            ClearSupplierDataFromGV();
            GetSupplierDetailsFromDView();
            CalculateExpenseAndSales();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            DateTime dateSales = dp_sales.Value;
            string dateextracted = dateSales.ToString("D");
            string totalSale = txt_POS.Text;
            string ftposamount = txtFTPOS.Text;
            string blueBox = txtBluebox.Text;
            string cashLeft = txtCashLeft.Text;
            string cashTakenFromPrevousSales = txtCashTakenForPrvDay.Text;
            CreateSalesRecord(dateextracted, totalSale, ftposamount, blueBox, cashLeft, cashTakenFromPrevousSales, otherExpense);

            if (sales != null)
            {
                bool rowexist = false;
                foreach (DataGridViewRow row in dg_salesRecord.Rows)
                {
                    if (row.Cells[0].Value != null && sales.Date.ToString() == row.Cells[0].Value.ToString())
                    {
                        rowexist = true;
                        MessageBox.Show("Record already exist in the table");
                        dgHandler.EditSalesGV(dg_salesRecord, sales);
                        break;
                    }

                }
                if (!rowexist)
                {
                    dgHandler.AddSalesGV(dg_salesRecord, sales);
                    dg_salesRecord.RefreshEdit();
                    dg_salesRecord.Refresh();
                }
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            double totalSupplierAmount = Convert.ToDouble(txtSupplierAmount.Text);
            double supplerAmountPaid = Convert.ToDouble(txtSupplierPaid.Text);
            double supplierchequeAmount = Convert.ToDouble(txt_cheque.Text);
            double supplierAmountDue = CalculateTotalDue(totalSupplierAmount,(supplierchequeAmount + supplerAmountPaid));
            DateTime dateSales = dpSupplierDate.Value;
            supplierName = cb_supplierName.SelectedValue.ToString(); 
            txtSuppAmountDue.Text = supplierAmountDue.ToString();
            CreateSupplierRecord(dateSales, supplierName, totalSupplierAmount, supplierchequeAmount, supplierAmountDue, supplerAmountPaid);
            if (supplier != null)
            {
                bool rowexist = false;
                foreach (DataGridViewRow row in dg_supplier.Rows)
                {
                    if (row.Cells[1].Value != null && supplier.SupplierName.ToString() == row.Cells[1].Value.ToString())
                    {
                        rowexist = true;
                        MessageBox.Show("Record already exist in the table");
                        dgHandler.EditSupplierGV(dg_supplier, supplier);
                        break;
                    }

                }
                if (!rowexist)
                {
                    dgHandler.AddSupplierGV(dg_supplier, supplier);
                    dg_supplier.RefreshEdit();
                    dg_supplier.Refresh();
                }
            }

        }

        private void CreateSupplierRecord(DateTime dateSales, string supplierName, double totalSupplierCost,double supplierchequeAmount,double supplierAmountDue, double supplerAmountPaid)
        {
            supplier.Date = dateSales;
            supplier.SupplierName = supplierName;
            supplier.TotalAmount = totalSupplierCost;
            supplier.chequeAmount = supplierchequeAmount;
            supplier.AmountDue = supplierAmountDue;
            supplier.AmountPaid = supplerAmountPaid;
        }

        private void CreateSalesRecord(string dateSales, string cashAmount, string ftposamount, string blueBox, string cashLeft, string cashTaken, double otherexpense)
        {
            sales.Date = dateSales;
            sales.CashAmount = decimal.Parse(cashAmount);
            sales.FtposAmount = decimal.Parse(ftposamount);
            sales.BlueBoxAmount = decimal.Parse(blueBox);
            sales.CashLeft = decimal.Parse(cashLeft);
            sales.CashTakenFromPreviousDay = decimal.Parse(cashTaken);
            sales.OtherExpense = otherexpense;          
            salesList.Add(sales);
        }

        private SalesExpense GetBalancedData()
        {
            SalesExpense salesExpense = new SalesExpense();
            salesExpense.Date =Convert.ToDateTime(dpSaleExpence.Value.ToString("D"));
            salesExpense.SupplierAmountPaid = Convert.ToDecimal(txtSupplierAmountPaid.Text);
            salesExpense.TotalFTPOSAmount = Convert.ToDecimal(txtFtposAmount.Text);
            salesExpense.EmployeeAmountPaid = Convert.ToDecimal(txtlbEmployeeAmountPaid.Text);
            salesExpense.CashLeftToday = Convert.ToDecimal(txtCashleftFinal.Text);
            salesExpense.CashTakenFromPreviousSale= Convert.ToDecimal(txtCashFromPrevousDayFinal.Text);
            salesExpense.TotalTillSale = Convert.ToDecimal(txtTotalTill.Text);
            salesExpense.TotalExpence= (salesExpense.EmployeeAmountPaid+ salesExpense.SupplierAmountPaid);
            return salesExpense;
        }


        private void UpdateSupplierAmountDue(decimal supplierAmountDue)
        {
            //txt_supplierAmountDue.Text = supplierAmountDue.ToString();
        }   

        private void btnFinalSubmit_Click(object sender, EventArgs e)
        {
            SalesExpense salesExpense= GetBalancedData();
            apiHandler.AddSalesExpenseData(salesExpense);

            if (dg_employeeWages != null)
            {
                dgHandler.PostEmployeeWagesGVRecords(apiHandler, dg_employeeWages);
            }
            else
            {
                MessageBox.Show("Cannot Employee  Details:Employee Table does not have any data");
            }
            if (dg_salesRecord != null)
            {
                dgHandler.PostSalesGVRecords(apiHandler, dg_salesRecord);
            }
            else
            {
                MessageBox.Show("Cannot Add Sales Details:Sales Table does not have any data");
            }
            if (dg_supplier != null)
            {
                dgHandler.PostSuplierGVRecords(apiHandler, dg_supplier);
            }
            else
            {
                MessageBox.Show("Cannot Add Supplier Details:Supplier Table does not have any data");
            }
        }


        private void CalculateExpenseAndSales()
        {
            txtlbEmployeeAmountPaid.Text = totalSalaryPaidToday.ToString();     
            txtCashleftFinal.Text = cashLeftToday.ToString();                 
            txtCashleftFinal.Text = cashLeftToday.ToString();
            txtCashFromPrevousDayFinal.Text = cashFromPrevousDay.ToString();
            txtSupplierAmountPaid.Text = supplerAmountPaid.ToString();
            cashFromPrevousDay = Convert.ToDouble(txtCashTakenForPrvDay.Text);           
            txtCashTakenForPrvDay.BackColor = Color.Orange;
            totalSale = cashLeftToday + totalFtposAmount + totalSalaryPaidToday + supplerAmountPaid+ supplerChequeAmount;            
            txtTotalTill.Text = totalSale.ToString();
            txtFtposAmount.Text = totalFtposAmount.ToString();
        }

        private void SalesDateChanged(object sender, EventArgs e)
        {
            txt_POS.Text = "0.0";
            txtFTPOS.Text = "0.0";
            txtBluebox.Text = "200";
            txtCashLeft.Text = "0.0";
            dg_salesRecord.Rows.Clear();
            dg_salesRecord.Refresh();
            ClearSalesDataFromGV();
        }      
        private void dpSupplierDate_ValueChanged(object sender, EventArgs e)
        {
            cb_supplierName.Text = "Select Supplier";
            txtSupplierAmount.Text = "0.0";
            txtSupplierPaid.Text = "0.0";
            txtSuppAmountDue.Text = "0.0";
            dg_supplier.Rows.Clear();
            dg_supplier.Refresh();
            ClearSupplierDataFromGV();        }

        private void ClearSupplierDataFromGV()
        {
            supplerAmountPaid = 0;
            supplierAmountDue = 0;
            supplerChequeAmount = 0;
        }
        private void ClearSalesDataFromGV()
        {
            totalFtposAmount = 0;
            totalPosAmount = 0;
            totalSale = 0;
            cashLeftToday = 0;
            cashFromPrevousDay = 0;
        }
        private void ClearEmployeeDataFromGV()
        {
            totalSalaryPaidToday = 0;
            totalSalaryDue = 0;
        }
        private void EmployeeDateChanged(object sender, EventArgs e)
        {
            dg_employeeWages.Rows.Clear();
            dg_employeeWages.Refresh();           
            ClearEmployeTextboxData();
            ClearEmployeeDataFromGV();
        }
        private void ClearEmployeTextboxData()
        {
            txt_totalHours.Text = "0.0";
            txt_totalAmount.Text = "0.0";
            txtSalaryPaid.Text = "0.0";
            txtSalaryDue.Text = "0.0";
        }

        private void btn_cashleft_Click(object sender, EventArgs e)
        {
            CalculateExpenseAndSales();
        }
        private void GetSalaryDetailsFromDView()
        {
            double empployeeSalaryAmount = 0;
            foreach (DataGridViewRow dr in dg_employeeWages.Rows)
            {
                try
                {
                    empployeeSalaryAmount += Convert.ToDouble(dr.Cells["Total_Amount"].Value);
                    totalSalaryDue += Convert.ToDouble(dr.Cells["Total_Due"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            totalSalaryPaidToday = empployeeSalaryAmount - totalSalaryDue;
        }
        private void GetSupplierDetailsFromDView()
        {
            foreach (DataGridViewRow dr in dg_supplier.Rows)
            {
                try
                {
                    totalSupplierAmount += Convert.ToDouble(dr.Cells["Supplier_Total_Amount"].Value);
                    supplerAmountPaid += Convert.ToDouble(dr.Cells["Supplier_Amount_Paid"].Value);
                    supplierAmountDue += Convert.ToDouble(dr.Cells["Supplier_Amount_Due"].Value);
                    supplerChequeAmount += Convert.ToDouble(dr.Cells["Cheque_Amount"].Value);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void GetSalesDetailsFromDView()
        {
            foreach (DataGridViewRow dr in dg_salesRecord.Rows)
            {
                try
                {
                    totalPosAmount += Convert.ToDouble(dr.Cells["Till_Sale"].Value);
                    totalFtposAmount+= Convert.ToDouble(dr.Cells["Ftpos_Amount"].Value);                   
                    cashLeftToday+= Convert.ToDouble(dr.Cells["Cash_Left"].Value);
                    cashFromPrevousDay += Convert.ToDouble(dr.Cells["Cash_From_Previous_Day"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void UpdateSuplierDueTextBox(double supplierdue)
        {
            txtSuppAmountDue.Text = supplierdue.ToString();
            txtSuppAmountDue.Refresh();
            txtSuppAmountDue.BackColor = Color.Yellow;
        }
        private void CalculateSupplierDue(object sender, MouseEventArgs e)
        {
         double supplierDue= CalculateTotalDue((Convert.ToDouble(txtSupplierAmount.Text)) , ((Convert.ToDouble(txtSupplierPaid.Text)) + (Convert.ToDouble(txt_cheque.Text))));
           UpdateSuplierDueTextBox(supplierDue);
        }
        
        private double CalculateTotalDue(double TotalAmount, double PaidAmount)
        {
            return TotalAmount - PaidAmount;
        }

        private void SalaryDueUpdate(object sender, MouseEventArgs e)
        {
            double salaryDue = CalculateTotalDue((Convert.ToDouble(txt_totalAmount.Text)), ((Convert.ToDouble(txtSalaryPaid.Text)) ));
            UpdateSalaryDueTextBox(salaryDue);
        }

        private void UpdateSalaryDueTextBox(double salaryDue)
        {
            txtSalaryDue.Text = salaryDue.ToString();
            txtSalaryDue.Refresh();
            txtSalaryDue.BackColor = Color.Yellow;
        }
    }
}
