namespace WindowsFormsApplication1
{
    partial class InvoiceView
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
            this.btnReadData = new System.Windows.Forms.Button();
            this.btnSearchInvoices = new System.Windows.Forms.Button();
            this.textboxInfo = new System.Windows.Forms.TextBox();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(574, 28);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(146, 23);
            this.btnReadData.TabIndex = 0;
            this.btnReadData.Text = "Data Yükleme";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSearchInvoices
            // 
            this.btnSearchInvoices.Location = new System.Drawing.Point(176, 44);
            this.btnSearchInvoices.Name = "btnSearchInvoices";
            this.btnSearchInvoices.Size = new System.Drawing.Size(95, 23);
            this.btnSearchInvoices.TabIndex = 1;
            this.btnSearchInvoices.Text = "Abone Ara";
            this.btnSearchInvoices.UseVisualStyleBackColor = true;
            this.btnSearchInvoices.Click += new System.EventHandler(this.SearchInvoices_Click);
            // 
            // textboxInfo
            // 
            this.textboxInfo.Location = new System.Drawing.Point(472, 441);
            this.textboxInfo.Name = "textboxInfo";
            this.textboxInfo.Size = new System.Drawing.Size(248, 20);
            this.textboxInfo.TabIndex = 2;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(24, 44);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(109, 20);
            this.txtInvoiceNumber.TabIndex = 3;
            // 
            // listView
            // 
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(24, 119);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(696, 284);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Abone Numarası";
           
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(574, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tüm Kayıtları Göster";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // InvoiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 464);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.textboxInfo);
            this.Controls.Add(this.btnSearchInvoices);
            this.Controls.Add(this.btnReadData);
            this.Name = "InvoiceView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Button btnSearchInvoices;
        private System.Windows.Forms.TextBox textboxInfo;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

