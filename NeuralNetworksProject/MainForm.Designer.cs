namespace NeuralNetworksProject
{
    partial class MainForm
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
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.pageBackPropagation = new System.Windows.Forms.TabPage();
            this.pageLevenberg = new System.Windows.Forms.TabPage();
            this.pageHopfield = new System.Windows.Forms.TabPage();
            this.tabCtrlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Controls.Add(this.pageBackPropagation);
            this.tabCtrlMain.Controls.Add(this.pageLevenberg);
            this.tabCtrlMain.Controls.Add(this.pageHopfield);
            this.tabCtrlMain.Location = new System.Drawing.Point(13, 13);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(831, 476);
            this.tabCtrlMain.TabIndex = 0;
            // 
            // pageBackPropagation
            // 
            this.pageBackPropagation.Location = new System.Drawing.Point(4, 22);
            this.pageBackPropagation.Name = "pageBackPropagation";
            this.pageBackPropagation.Padding = new System.Windows.Forms.Padding(3);
            this.pageBackPropagation.Size = new System.Drawing.Size(823, 450);
            this.pageBackPropagation.TabIndex = 0;
            this.pageBackPropagation.Text = "BackPropagation";
            this.pageBackPropagation.UseVisualStyleBackColor = true;
            // 
            // pageLevenberg
            // 
            this.pageLevenberg.Location = new System.Drawing.Point(4, 22);
            this.pageLevenberg.Name = "pageLevenberg";
            this.pageLevenberg.Padding = new System.Windows.Forms.Padding(3);
            this.pageLevenberg.Size = new System.Drawing.Size(823, 450);
            this.pageLevenberg.TabIndex = 1;
            this.pageLevenberg.Text = "Levenberg";
            this.pageLevenberg.UseVisualStyleBackColor = true;
            // 
            // pageHopfield
            // 
            this.pageHopfield.Location = new System.Drawing.Point(4, 22);
            this.pageHopfield.Name = "pageHopfield";
            this.pageHopfield.Padding = new System.Windows.Forms.Padding(3);
            this.pageHopfield.Size = new System.Drawing.Size(823, 450);
            this.pageHopfield.TabIndex = 2;
            this.pageHopfield.Text = "Hopfield";
            this.pageHopfield.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 501);
            this.Controls.Add(this.tabCtrlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabCtrlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.TabPage pageBackPropagation;
        private System.Windows.Forms.TabPage pageLevenberg;
        private System.Windows.Forms.TabPage pageHopfield;
    }
}

