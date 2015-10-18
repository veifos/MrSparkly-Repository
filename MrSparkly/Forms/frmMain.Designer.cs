namespace MrSparkly.forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnOrderLines = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEmployees
            // 
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnEmployees.Location = new System.Drawing.Point(103, 78);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(172, 78);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnProducts.Location = new System.Drawing.Point(343, 78);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(172, 78);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnOrderLines
            // 
            this.btnOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnOrderLines.Location = new System.Drawing.Point(346, 181);
            this.btnOrderLines.Name = "btnOrderLines";
            this.btnOrderLines.Size = new System.Drawing.Size(172, 78);
            this.btnOrderLines.TabIndex = 6;
            this.btnOrderLines.Text = "Order Lines";
            this.btnOrderLines.UseVisualStyleBackColor = true;
            this.btnOrderLines.Click += new System.EventHandler(this.btnOrderLines_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnOrders.Location = new System.Drawing.Point(106, 181);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(172, 78);
            this.btnOrders.TabIndex = 5;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnOrderLines);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnEmployees);
            this.Name = "frmMain";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Controls.SetChildIndex(this.pnlControls, 0);
            this.Controls.SetChildIndex(this.btnEmployees, 0);
            this.Controls.SetChildIndex(this.btnProducts, 0);
            this.Controls.SetChildIndex(this.btnOrders, 0);
            this.Controls.SetChildIndex(this.btnOrderLines, 0);
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnOrderLines;
        private System.Windows.Forms.Button btnOrders;
    }
}

