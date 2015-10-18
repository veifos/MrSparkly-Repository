using MrSparkly.Data;
using MrSparkly.Meta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MrSparkly.Forms.Orders
{
    public partial class frmOrder : frmTemplateDetails
    {
        #region vars

        Order order;

        #endregion vars


        #region init

        private void frmOrder_Load(object sender, EventArgs e)
        {

        }

        public frmOrder()
        {
            InitializeComponent();
            order = new Order();
        }

        public frmOrder(long primary_key)
        {
            InitializeComponent();
            order = new Order(primary_key);
            DisplayRecord();
        }

        #endregion init


        #region events

        private void btnSave_Click(object sender, EventArgs e)
        {
            order.EmployeeID = Convert.ToInt64(txtEmployeeID.Text);
            order.TimeOfSale = Convert.ToDateTime (dtpSale.Text);

            order.SaveData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            order.DeleteRecord();
            this.Close();
        }

        #endregion events


        #region aux

        private void DisplayRecord()
        {
            txtID.Text = order.ID.ToString();
            txtEmployeeID.Text = order.EmployeeID.ToString();
            dtpSale.Text = order.TimeOfSale.ToString();
        }

        #endregion aux



      
        }
    }
