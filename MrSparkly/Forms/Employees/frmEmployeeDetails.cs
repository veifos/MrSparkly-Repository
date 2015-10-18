using MrSparkly.Meta;
using MrSparkly.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MrSparkly.Forms.Employees
{
    public partial class frmEmployeeDetails : frmTemplateDetails
    {

         #region vars

        Employee employee;

        #endregion vars


        #region init

        private void frmEmployeeDetails_Load(object sender, EventArgs e)
        {

        }

        public frmEmployeeDetails()
        {
            InitializeComponent();
            employee = new Employee();
        }
        
        //This displays all the currently saved employee records
        public frmEmployeeDetails(long primary_key)
        {
            InitializeComponent();
            employee = new Employee(primary_key);
            DisplayRecord();
        }

        #endregion init


        #region events

        //This saves the data within the fields
        private void btnSave_Click(object sender, EventArgs e)
        {
            employee.EmployeeFirstName = txtFirstName.Text;
            employee.EmployeeLastName = txtLastName.Text;
            employee.Username = txtUsername.Text;
            employee.Password = txtPassword.Text;
            employee.Admin = cbAdmin.Checked;
            employee.Sales = cbSales.Checked;
            employee.SaveData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            employee.DeleteRecord();
            this.Close();
        }

        #endregion events


        #region aux

        //This displays the selected record on to the form
        private void DisplayRecord()
        {
            txtID.Text = employee.ID.ToString();
            txtFirstName.Text = employee.EmployeeFirstName;
            txtLastName.Text = employee.EmployeeLastName;
            txtUsername.Text = employee.Username;
            txtPassword.Text = employee.Password;
            cbAdmin.Checked = employee.Admin;
            cbSales.Checked = employee.Sales;
        }

        #endregion aux

      
        }
    }
