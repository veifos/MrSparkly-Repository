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
    public partial class frmOrderLines : frmTemplateDetails
    {

         #region vars

        OrderLine orderLine;

        #endregion vars


        #region init

        private void frmOrderLines_Load(object sender, EventArgs e)
        {

        }

        public frmOrderLines()
        {
            InitializeComponent();
            orderLine = new OrderLine();
        }

        public frmOrderLines(long primary_key)
        {
            InitializeComponent();
            orderLine = new OrderLine(primary_key);
            DisplayRecord();
        }

        #endregion init


        #region events

        private void btnSave_Click(object sender, EventArgs e)
        {
            orderLine.OrderID = Convert.ToInt64(txtOrderID.Text);
            orderLine.ProductID = Convert.ToInt64 (txtProductID.Text);

            orderLine.SaveData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            orderLine.DeleteRecord();
            this.Close();
        }

        #endregion events


        #region aux

        private void DisplayRecord()
        {
            txtID.Text = orderLine.ID.ToString();
            txtOrderID.Text = orderLine.OrderID.ToString();
            txtProductID.Text = orderLine.ProductID.ToString();
        }

        #endregion aux

      
        }
    }
