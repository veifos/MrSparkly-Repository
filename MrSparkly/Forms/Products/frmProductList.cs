using DbConnection;
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

namespace MrSparkly.Forms.Products
{
    public partial class frmProductList : frmTemplateList
    {
        #region vars

        dbConn db;

        #endregion vars


        #region init

         public frmProductList()
        {
            InitializeComponent();
        }

        //loads the data from the database onto the form
        private void frmProductList_Load(object sender, EventArgs e)
        {
            db = new dbConn(Utilities.DB_FILE);
            dgvList.DataSource = db.getDataTable(Data.Product.TABLE_NAME);
        }

        #endregion init


        #region events

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //long id = (long)dgvList[Product.PRIMARY_KEY, dgvList.CurrentCell.RowIndex].Value;
            long id = long.Parse(dgvList[Product.PRIMARY_KEY, dgvList.CurrentCell.RowIndex].Value.ToString());
            ShowForm(new Forms.Products.frmProductDetails(id));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.Products.frmProductDetails());
        }

        #endregion events

    }
}
