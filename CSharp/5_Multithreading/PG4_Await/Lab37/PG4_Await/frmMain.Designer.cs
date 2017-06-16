namespace PG4_Await
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
            this.pnlRecentOrderList = new System.Windows.Forms.Panel();
            this.dgvRecentOrderList = new System.Windows.Forms.DataGridView();
            this.lblRecentOrderList = new System.Windows.Forms.Label();
            this.pnlOrderTotalCost = new System.Windows.Forms.Panel();
            this.txtOrderTotalCost = new System.Windows.Forms.TextBox();
            this.lblOrderTotalCost = new System.Windows.Forms.Label();
            this.pnlOrderTotalQuantity = new System.Windows.Forms.Panel();
            this.txtOrderTotalQuantity = new System.Windows.Forms.TextBox();
            this.lblOrderTotalQuantity = new System.Windows.Forms.Label();
            this.pnlRecentOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrderList)).BeginInit();
            this.pnlOrderTotalCost.SuspendLayout();
            this.pnlOrderTotalQuantity.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRecentOrderList
            // 
            this.pnlRecentOrderList.Controls.Add(this.dgvRecentOrderList);
            this.pnlRecentOrderList.Controls.Add(this.lblRecentOrderList);
            this.pnlRecentOrderList.Location = new System.Drawing.Point(43, 31);
            this.pnlRecentOrderList.Name = "pnlRecentOrderList";
            this.pnlRecentOrderList.Size = new System.Drawing.Size(437, 267);
            this.pnlRecentOrderList.TabIndex = 0;
            // 
            // dgvRecentOrderList
            // 
            this.dgvRecentOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvRecentOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentOrderList.Location = new System.Drawing.Point(6, 36);
            this.dgvRecentOrderList.Name = "dgvRecentOrderList";
            this.dgvRecentOrderList.RowTemplate.Height = 27;
            this.dgvRecentOrderList.Size = new System.Drawing.Size(425, 226);
            this.dgvRecentOrderList.TabIndex = 1;
            // 
            // lblRecentOrderList
            // 
            this.lblRecentOrderList.AutoSize = true;
            this.lblRecentOrderList.Location = new System.Drawing.Point(3, 9);
            this.lblRecentOrderList.Name = "lblRecentOrderList";
            this.lblRecentOrderList.Size = new System.Drawing.Size(122, 15);
            this.lblRecentOrderList.TabIndex = 0;
            this.lblRecentOrderList.Text = "최근 주문 리스트";
            // 
            // pnlOrderTotalCost
            // 
            this.pnlOrderTotalCost.Controls.Add(this.txtOrderTotalCost);
            this.pnlOrderTotalCost.Controls.Add(this.lblOrderTotalCost);
            this.pnlOrderTotalCost.Location = new System.Drawing.Point(581, 31);
            this.pnlOrderTotalCost.Name = "pnlOrderTotalCost";
            this.pnlOrderTotalCost.Size = new System.Drawing.Size(250, 150);
            this.pnlOrderTotalCost.TabIndex = 1;
            // 
            // txtOrderTotalCost
            // 
            this.txtOrderTotalCost.Font = new System.Drawing.Font("Gulim", 50F);
            this.txtOrderTotalCost.Location = new System.Drawing.Point(3, 36);
            this.txtOrderTotalCost.Name = "txtOrderTotalCost";
            this.txtOrderTotalCost.Size = new System.Drawing.Size(244, 103);
            this.txtOrderTotalCost.TabIndex = 1;
            this.txtOrderTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOrderTotalCost
            // 
            this.lblOrderTotalCost.AutoSize = true;
            this.lblOrderTotalCost.Location = new System.Drawing.Point(4, 4);
            this.lblOrderTotalCost.Name = "lblOrderTotalCost";
            this.lblOrderTotalCost.Size = new System.Drawing.Size(72, 15);
            this.lblOrderTotalCost.TabIndex = 0;
            this.lblOrderTotalCost.Text = "주문 총액";
            // 
            // pnlOrderTotalQuantity
            // 
            this.pnlOrderTotalQuantity.Controls.Add(this.txtOrderTotalQuantity);
            this.pnlOrderTotalQuantity.Controls.Add(this.lblOrderTotalQuantity);
            this.pnlOrderTotalQuantity.Location = new System.Drawing.Point(581, 236);
            this.pnlOrderTotalQuantity.Name = "pnlOrderTotalQuantity";
            this.pnlOrderTotalQuantity.Size = new System.Drawing.Size(250, 107);
            this.pnlOrderTotalQuantity.TabIndex = 2;
            // 
            // txtOrderTotalQuantity
            // 
            this.txtOrderTotalQuantity.Font = new System.Drawing.Font("Gulim", 30F);
            this.txtOrderTotalQuantity.Location = new System.Drawing.Point(3, 33);
            this.txtOrderTotalQuantity.Name = "txtOrderTotalQuantity";
            this.txtOrderTotalQuantity.Size = new System.Drawing.Size(244, 65);
            this.txtOrderTotalQuantity.TabIndex = 1;
            this.txtOrderTotalQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOrderTotalQuantity
            // 
            this.lblOrderTotalQuantity.AutoSize = true;
            this.lblOrderTotalQuantity.Location = new System.Drawing.Point(4, 4);
            this.lblOrderTotalQuantity.Name = "lblOrderTotalQuantity";
            this.lblOrderTotalQuantity.Size = new System.Drawing.Size(92, 15);
            this.lblOrderTotalQuantity.TabIndex = 0;
            this.lblOrderTotalQuantity.Text = "주문 총 수량";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 372);
            this.Controls.Add(this.pnlOrderTotalQuantity);
            this.Controls.Add(this.pnlOrderTotalCost);
            this.Controls.Add(this.pnlRecentOrderList);
            this.Name = "frmMain";
            this.Text = "주문 대시보드";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlRecentOrderList.ResumeLayout(false);
            this.pnlRecentOrderList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrderList)).EndInit();
            this.pnlOrderTotalCost.ResumeLayout(false);
            this.pnlOrderTotalCost.PerformLayout();
            this.pnlOrderTotalQuantity.ResumeLayout(false);
            this.pnlOrderTotalQuantity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRecentOrderList;
        private System.Windows.Forms.Label lblRecentOrderList;
        private System.Windows.Forms.Panel pnlOrderTotalCost;
        private System.Windows.Forms.TextBox txtOrderTotalCost;
        private System.Windows.Forms.Label lblOrderTotalCost;
        private System.Windows.Forms.Panel pnlOrderTotalQuantity;
        private System.Windows.Forms.TextBox txtOrderTotalQuantity;
        private System.Windows.Forms.Label lblOrderTotalQuantity;
        private System.Windows.Forms.DataGridView dgvRecentOrderList;
    }
}

