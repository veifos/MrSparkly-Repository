using MrSparkly.Forms;
using MrSparkly.Meta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MrSparkly.forms
{
    public partial class frmMain : frmTemplate
    {

        #region init

        public frmMain()
        {
            InitializeComponent();
            Debug.Print("Debug print!");
            Debug.Assert(1 == 1);
        }

        #endregion init

        #region event
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (new frmLogin().ShowDialog() != DialogResult.Cancel)
            {
                btnEmployees.Enabled = Utilities.User.Admin;
                btnProducts.Enabled = Utilities.User.Admin;
                btnOrders.Enabled = Utilities.User.Sales;
                btnOrderLines.Enabled = Utilities.User.Sales;
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.Products.frmProductList());
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.Employees.frmEmployeeList());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.Orders.frmOrderList());
        }

        private void btnOrderLines_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.OrderLines.frmOrderLinesList());
        }
        #endregion event
    }
}