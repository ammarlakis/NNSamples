namespace NeuralNetworksProject
{
    partial class TrainingInputDialog
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblEpoches = new System.Windows.Forms.Label();
            this.txtbxEpoches = new System.Windows.Forms.TextBox();
            this.txtbxErrorLimit = new System.Windows.Forms.TextBox();
            this.lblErrorLimit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(53, 90);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.OkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // lblEpoches
            // 
            this.lblEpoches.Location = new System.Drawing.Point(12, 17);
            this.lblEpoches.Name = "lblEpoches";
            this.lblEpoches.Size = new System.Drawing.Size(100, 23);
            this.lblEpoches.TabIndex = 3;
            this.lblEpoches.Text = "Epoches    :";
            // 
            // txtbxEpoches
            // 
            this.txtbxEpoches.Location = new System.Drawing.Point(144, 14);
            this.txtbxEpoches.Name = "txtbxEpoches";
            this.txtbxEpoches.Size = new System.Drawing.Size(100, 20);
            this.txtbxEpoches.TabIndex = 4;
            // 
            // txtbxErrorLimit
            // 
            this.txtbxErrorLimit.Location = new System.Drawing.Point(144, 40);
            this.txtbxErrorLimit.Name = "txtbxErrorLimit";
            this.txtbxErrorLimit.Size = new System.Drawing.Size(100, 20);
            this.txtbxErrorLimit.TabIndex = 5;
            // 
            // lblErrorLimit
            // 
            this.lblErrorLimit.Location = new System.Drawing.Point(12, 43);
            this.lblErrorLimit.Name = "lblErrorLimit";
            this.lblErrorLimit.Size = new System.Drawing.Size(100, 23);
            this.lblErrorLimit.TabIndex = 3;
            this.lblErrorLimit.Text = "Error Limit  :";
            // 
            // TrainingInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 125);
            this.ControlBox = false;
            this.Controls.Add(this.txtbxErrorLimit);
            this.Controls.Add(this.txtbxEpoches);
            this.Controls.Add(this.lblErrorLimit);
            this.Controls.Add(this.lblEpoches);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TrainingInputDialog";
            this.Text = "Enter Training Parameters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblEpoches;
        public  System.Windows.Forms.TextBox txtbxEpoches;
        public  System.Windows.Forms.TextBox txtbxErrorLimit;
        private System.Windows.Forms.Label lblErrorLimit;
    }
}