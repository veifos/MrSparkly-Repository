using MrSparkly.Data;
using MrSparkly.Meta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MrSparkly.Forms.Products
{
     public partial class frmProductDetails : frmTemplateDetails
    {

        #region vars

        Product product;

        #endregion vars


        #region init


        public frmProductDetails()
        {
            InitializeComponent();
            product = new Product();
        }

        public frmProductDetails(long primary_key)
        {
            InitializeComponent();
            product = new Product(primary_key);
            DisplayRecord();
        }

        #endregion init


        #region events

        private void btnSave_Click(object sender, EventArgs e)
        {
            product.Description = txtDescription.Text;
            product.Price = nudPrice.Value;
            product.SaveData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            product.DeleteRecord();
            this.Close();
        }

        #endregion events


        #region aux

        private void DisplayRecord()
    {
        txtID.Text = product.ID.ToString();
        txtDescription.Text = product.Description;
        nudPrice.Value = product.Price;
    }

        #endregion aux
    }
}