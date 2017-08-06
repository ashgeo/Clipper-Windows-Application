using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clipper_CRM_Software
{
    class DataGridViewHandler
    {
        //internal void EditEmployeeWagesGV(int empID, EmployeeWages employeeWages, DataGridView dg_employeeWages, int rowIndex)
        //{
        //    foreach (DataGridViewRow row in dg_employeeWages.Rows)
        //    {
        //        if (rowIndex != 0)
        //        {
        //            rowIndex = rowIndex - 1;
        //        }
        //       if ( row.Index== rowIndex)
        //        {
        //            row.Cells[1].Value = employeeWages.PayDate;
        //            row.Cells[2].Value = employeeWages.EmpName;
        //            row.Cells[3].Value = employeeWages.Role;
        //            row.Cells[4].Value = employeeWages.StartTime;
        //            row.Cells[5].Value = employeeWages.FinishTime;
        //            row.Cells[6].Value = employeeWages.TotalHours;
        //            row.Cells[7].Value = employeeWages.TotalAmount;
        //            row.Cells[8].Value = employeeWages.IsPaid;
        //            row.Cells[9].Value = employeeWages.PayDue;
        //        }
        //    }
        //}

        internal void AddEmployeeGV(DataGridView dg_employeeWages, EmployeeWages empWages)
        {
            {
                try
                {
                    DataGridViewRow row = (DataGridViewRow)dg_employeeWages.Rows[0].Clone();
                    dg_employeeWages.Rows.Add(empWages.EmpID, empWages.PayDate, empWages.EmpName, empWages.Role, empWages.StartTime.TimeOfDay, empWages.FinishTime.TimeOfDay, empWages.TotalHours, empWages.TotalAmount, empWages.TotalPaid, empWages.PayDue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Add slaes record to data grid view
        /// </summary>
        /// <param name="dg_sales"></param>
        /// <param name="sales"></param>

        internal void AddSalesGV(DataGridView dg_sales, Sales sales)
        {
            {
                try
                {
                    DataGridViewRow row = (DataGridViewRow)dg_sales.Rows[0].Clone();
                    dg_sales.Rows.Add(sales.Date,   sales.CashAmount, sales.FtposAmount, sales.BlueBoxAmount,  sales.CashLeft, sales.CashTakenFromPreviousDay);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        internal void AddSupplierGV(DataGridView dg_supplier, Supplier supplier)
        {
            {
                try
                {
                    DataGridViewRow row = (DataGridViewRow)dg_supplier.Rows[0].Clone();
                    dg_supplier.Rows.Add(supplier.Date, supplier.SupplierName, supplier.TotalAmount, supplier.AmountPaid,supplier.chequeAmount, supplier.AmountDue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        internal void EditEmployeeGV(DataGridView dg_employeeWages, EmployeeWages employeeWages)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dg_employeeWages.Rows[0].Clone();
                for (int i = 0; i < dg_employeeWages.Rows.Count - 1; i++)
                {
                    string id = dg_employeeWages.Rows[i].Cells[0].Value.ToString();
                    if (Int32.Parse(id) == employeeWages.EmpID)
                    {
                        dg_employeeWages.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                      
                        dg_employeeWages.Rows[i].Cells[1].Value = employeeWages.PayDate;
                        dg_employeeWages.Rows[i].Cells[2].Value = employeeWages.EmpName;
                        dg_employeeWages.Rows[i].Cells[3].Value = employeeWages.Role;
                        dg_employeeWages.Rows[i].Cells[4].Value = employeeWages.StartTime;
                        dg_employeeWages.Rows[i].Cells[5].Value = employeeWages.FinishTime;
                        dg_employeeWages.Rows[i].Cells[6].Value = employeeWages.TotalHours;
                        dg_employeeWages.Rows[i].Cells[7].Value = employeeWages.TotalAmount;
                        dg_employeeWages.Rows[i].Cells[8].Value = employeeWages.TotalPaid ;
                        dg_employeeWages.Rows[i].Cells[9].Value = employeeWages.PayDue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void EditSalesGV(DataGridView dg_salesRecord, Sales sales)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dg_salesRecord.Rows[0].Clone();
                for (int i = 0; i < dg_salesRecord.Rows.Count - 1; i++)
                {
                    string saleDate = dg_salesRecord.Rows[i].Cells[0].Value.ToString();
                    if (saleDate == sales.Date)
                    {
                        dg_salesRecord.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                        dg_salesRecord.Rows[i].Cells[0].Value = sales.Date;
                        dg_salesRecord.Rows[i].Cells[1].Value = sales.CashAmount;
                        dg_salesRecord.Rows[i].Cells[2].Value = sales.FtposAmount;                   
                        dg_salesRecord.Rows[i].Cells[3].Value = sales.BlueBoxAmount;
                        dg_salesRecord.Rows[i].Cells[4].Value = sales.CashLeft;
                        dg_salesRecord.Rows[i].Cells[5].Value = sales.CashTakenFromPreviousDay;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        internal void EditSupplierGV(DataGridView dg_supplier, Supplier supplier)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dg_supplier.Rows[0].Clone();
                for (int i = 0; i < dg_supplier.Rows.Count - 1; i++)
                {
                    string supplierName = dg_supplier.Rows[i].Cells[1].Value.ToString();
                    if (supplierName == supplier.SupplierName)
                    {
                        dg_supplier.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                        dg_supplier.Rows[i].Cells[0].Value = supplier.Date;
                        dg_supplier.Rows[i].Cells[1].Value = supplier.SupplierName;                     
                        dg_supplier.Rows[i].Cells[2].Value = supplier.TotalAmount;
                        dg_supplier.Rows[i].Cells[3].Value = supplier.AmountPaid;
                        dg_supplier.Rows[i].Cells[4].Value = supplier.chequeAmount;
                        dg_supplier.Rows[i].Cells[5].Value = supplier.AmountDue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void PostEmployeeWagesGVRecords(APIHandler apiHandler, DataGridView dg_employeeWages)
        {
            List<EmployeeWages> empWagesList = new List<EmployeeWages>();
            EmployeeWages empWages = null; ;
            foreach (DataGridViewRow row in dg_employeeWages.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    empWages = new EmployeeWages();
                    empWages.EmpID = Convert.ToInt32(row.Cells[0].Value.ToString());
                    empWages.PayDate = Convert.ToDateTime(row.Cells[1].Value.ToString());
                    empWages.EmpName = row.Cells[2].Value.ToString();
                    empWages.Role = row.Cells[3].Value.ToString();
                    empWages.StartTime = Convert.ToDateTime(row.Cells[4].Value.ToString());
                    empWages.FinishTime = Convert.ToDateTime(row.Cells[5].Value.ToString());
                    empWages.TotalHours = Convert.ToDouble(row.Cells[6].Value.ToString());
                    empWages.TotalAmount = Convert.ToDouble(row.Cells[7].Value.ToString());
                    empWages.TotalPaid = Convert.ToDouble(row.Cells[8].Value.ToString());
                    empWages.PayDue = Convert.ToDouble(row.Cells[9].Value.ToString());
                    empWagesList.Add(empWages);
                }
            }
            if(empWagesList.Count>0)
                {
                apiHandler.AddEmployeeWagesData(empWagesList);
            }
        }

        internal void PostSalesGVRecords(APIHandler apiHandler, DataGridView dg_salesRecord)
        {

            List<Sales> salesList = new List<Sales>();
            Sales sales = null; ;
            foreach (DataGridViewRow row in dg_salesRecord.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    sales = new Sales();
                    sales.Date = Convert.ToString(row.Cells[0].Value.ToString());
                    sales.TotalSale = Convert.ToDecimal(row.Cells[1].Value.ToString());
                    sales.FtposAmount = Convert.ToDecimal(row.Cells[2].Value.ToString());                   
                    sales.BlueBoxAmount = Convert.ToDecimal(row.Cells[3].Value.ToString());
                    sales.CashLeft = Convert.ToDecimal(row.Cells[4].Value.ToString());                   
                    salesList.Add(sales);
                }
            }
            if (salesList.Count>0)
            {
                apiHandler.AddSalesWagesData(salesList);
            }
        }



        internal void PostSuplierGVRecords(APIHandler apiHandler, DataGridView dg_salesRecord)
        {

            List<Supplier> supplierList = new List<Supplier>();
            Supplier supplier = null; ;
            foreach (DataGridViewRow row in dg_salesRecord.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    supplier = new Supplier();
                    //  supplier.SupplierID = 0;
                    supplier.Date = Convert.ToDateTime(row.Cells[0].Value.ToString());
                    supplier.SupplierName = Convert.ToString(row.Cells[1].Value.ToString());                  
                    supplier.TotalAmount = Convert.ToDouble(row.Cells[2].Value.ToString());
                    supplier.AmountPaid = Convert.ToDouble(row.Cells[3].Value.ToString());
                    supplier.AmountDue = Convert.ToDouble(row.Cells[4].Value.ToString());
                    supplierList.Add(supplier);
                }
            }
            if (supplierList.Count>0)
            {
                apiHandler.AddSupplierData(supplierList);
            }
        }

    }
}
