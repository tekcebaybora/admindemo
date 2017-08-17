namespace TKN489.UserController
{
    partial class ucZigzag
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
            this.listZigZag = new System.Windows.Forms.ListBox();
            this.btnZigZag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Info.Location = new System.Drawing.Point(21, 23);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(510, 24);
            this.Info.TabIndex = 1;
            this.Info.Text = "Mod3=Zig, Mod5=zag,Mod15=ZigZag<100<Mod15=ZagZig\r\n";
            // 
            // listZigZag
            // 
            this.listZigZag.FormattingEnabled = true;
            this.listZigZag.Location = new System.Drawing.Point(25, 64);
            this.listZigZag.Name = "listZigZag";
            this.listZigZag.Size = new System.Drawing.Size(459, 238);
            this.listZigZag.TabIndex = 2;
            this.listZigZag.SelectedIndexChanged += new System.EventHandler(this.listZigZag_SelectedIndexChanged);
            // 
            // btnZigZag
            // 
            this.btnZigZag.Location = new System.Drawing.Point(490, 64);
            this.btnZigZag.Name = "btnZigZag";
            this.btnZigZag.Size = new System.Drawing.Size(75, 23);
            this.btnZigZag.TabIndex = 3;
            this.btnZigZag.Text = "Get 200";
            this.btnZigZag.UseVisualStyleBackColor = true;
            this.btnZigZag.Click += new System.EventHandler(this.btnZigZag_Click);
            // 
            // ucZigzag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnZigZag);
            this.Controls.Add(this.listZigZag);
            this.Controls.Add(this.Info);
            this.Name = "ucZigzag";
            this.Size = new System.Drawing.Size(583, 314);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.ListBox listZigZag;
        private System.Windows.Forms.Button btnZigZag;
    }
}
