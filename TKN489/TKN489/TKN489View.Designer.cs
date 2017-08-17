namespace TKN489
{
    partial class TKN489View
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
            this.btnCalculation = new System.Windows.Forms.Button();
            this.btnZigZag = new System.Windows.Forms.Button();
            this.btnMultiplication = new System.Windows.Forms.Button();
            this.btnReadSort = new System.Windows.Forms.Button();
            this.btnFibonacci = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalculation
            // 
            this.btnCalculation.Location = new System.Drawing.Point(12, 320);
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Size = new System.Drawing.Size(100, 23);
            this.btnCalculation.TabIndex = 0;
            this.btnCalculation.Text = "Calculation";
            this.btnCalculation.UseVisualStyleBackColor = true;
            this.btnCalculation.Click += new System.EventHandler(this.btnCalculation_Click);
            // 
            // btnZigZag
            // 
            this.btnZigZag.Location = new System.Drawing.Point(116, 320);
            this.btnZigZag.Name = "btnZigZag";
            this.btnZigZag.Size = new System.Drawing.Size(100, 23);
            this.btnZigZag.TabIndex = 1;
            this.btnZigZag.Text = "ZigZag";
            this.btnZigZag.UseVisualStyleBackColor = true;
            this.btnZigZag.Click += new System.EventHandler(this.btnZigZag_Click);
            // 
            // btnMultiplication
            // 
            this.btnMultiplication.Location = new System.Drawing.Point(222, 320);
            this.btnMultiplication.Name = "btnMultiplication";
            this.btnMultiplication.Size = new System.Drawing.Size(100, 23);
            this.btnMultiplication.TabIndex = 2;
            this.btnMultiplication.Text = "Multiplication T.";
            this.btnMultiplication.UseVisualStyleBackColor = true;
            this.btnMultiplication.Click += new System.EventHandler(this.btnMultiplication_Click);
            // 
            // btnReadSort
            // 
            this.btnReadSort.Location = new System.Drawing.Point(328, 320);
            this.btnReadSort.Name = "btnReadSort";
            this.btnReadSort.Size = new System.Drawing.Size(100, 23);
            this.btnReadSort.TabIndex = 3;
            this.btnReadSort.Text = "Read/Sort";
            this.btnReadSort.UseVisualStyleBackColor = true;
            this.btnReadSort.Click += new System.EventHandler(this.btnReadSort_Click);
            // 
            // btnFibonacci
            // 
            this.btnFibonacci.Location = new System.Drawing.Point(434, 320);
            this.btnFibonacci.Name = "btnFibonacci";
            this.btnFibonacci.Size = new System.Drawing.Size(100, 23);
            this.btnFibonacci.TabIndex = 4;
            this.btnFibonacci.Text = "Fibonacci";
            this.btnFibonacci.UseVisualStyleBackColor = true;
            this.btnFibonacci.Click += new System.EventHandler(this.btnFibonacci_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 314);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 87);
            this.label1.TabIndex = 0;
            this.label1.Text = "TKN489 Projesi\r\n\r\nÇağrı Baybora Tekçe";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TKN489View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 351);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFibonacci);
            this.Controls.Add(this.btnReadSort);
            this.Controls.Add(this.btnMultiplication);
            this.Controls.Add(this.btnZigZag);
            this.Controls.Add(this.btnCalculation);
            this.Name = "TKN489View";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalculation;
        private System.Windows.Forms.Button btnZigZag;
        private System.Windows.Forms.Button btnMultiplication;
        private System.Windows.Forms.Button btnReadSort;
        private System.Windows.Forms.Button btnFibonacci;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

