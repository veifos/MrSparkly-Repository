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

namespace MrSparkly.Forms.OrderLines
{
    public partial class frmOrderLinesList : frmTemplateList
    { 
        #region vars

        dbConn db;

        #endregion vars


        #region init

        public frmOrderLinesList()
        {
            InitializeComponent();
        }

        // Loads the data from the database onto the form
        private void frmOrderLinesList_Load(object sender, EventArgs e)
        {
            db = new dbConn(Utilities.DB_FILE);
            dgvList.DataSource = db.getDataTable(Data.Order.TABLE_NAME);
        }

        #endregion init


        #region events

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            //long id = (long)dgvList[Product.PRIMARY_KEY, dgvList.CurrentCell.RowIndex].Value;
            long id = long.Parse(dgvList[Order.PRIMARY_KEY, dgvList.CurrentCell.RowIndex].Value.ToString());
            ShowForm(new Forms.Orders.frmOrderLines(id));
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            ShowForm(new Forms.Orders.frmOrderLines());
        }

        #endregion events




    }
}
