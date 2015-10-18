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

namespace MrSparkly.Meta
{
    public partial class frmTemplate : Form
    {
        #region init
 public frmTemplate()
        {
            InitializeComponent();
        }

 public void ShowForm(Form frm)
        {
            frm.Shown += frm_Shown;
            frm.FormClosing += frm_FormClosing;
            frm.Show();
        }

        void frm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }


        #endregion init


        #region event
 private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #endregion event

        #region aux



        #endregion aux

    }
}
