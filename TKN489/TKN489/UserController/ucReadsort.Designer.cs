namespace TKN489.UserController
{
    partial class ucReadsort
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Info = new System.Windows.Forms.Label();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Info.Location = new System.Drawing.Point(21, 23);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(252, 72);
            this.Info.TabIndex = 3;
            this.Info.Text = "Read File And Sort Numbers\r\n\r\n\r\n";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(483, 72);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(100, 23);
            this.btnLoadData.TabIndex = 4;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(483, 102);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(100, 23);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Sort Numbers";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(25, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(452, 225);
            this.listBox1.TabIndex = 7;
            // 
            // ucReadsort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.Info);
            this.Name = "ucReadsort";
            this.Size = new System.Drawing.Size(583, 314);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.ListBox listBox1;
    }
}
