namespace NeuralNetworksProject
{
    partial class LayerControl
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
            this.lblLayer = new System.Windows.Forms.Label();
            this.comboLayerAct = new System.Windows.Forms.ComboBox();
            this.numNeuronsLayer = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numNeuronsLayer)).BeginInit();
            this.SuspendLayout();
            //
            // lblLayer
            //
            this.lblLayer.AutoSize = true;
            this.lblLayer.Location = new System.Drawing.Point(3, 0);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(33, 13);
            this.lblLayer.TabIndex = 4;
            this.lblLayer.Text = "Layer";
            //
            // comboLayerAct
            //
            this.comboLayerAct.DataSource = new NeuralNetworksProject.LayerControl.Functions[]
            {
                NeuralNetworksProject.LayerControl.Functions.Linear,
                NeuralNetworksProject.LayerControl.Functions.Threashold,
                NeuralNetworksProject.LayerControl.Functions.Sigmoid,
                NeuralNetworksProject.LayerControl.Functions.Bibolar,
                NeuralNetworksProject.LayerControl.Functions.Bernoulli,
                NeuralNetworksProject.LayerControl.Functions.Gaussian,
                NeuralNetworksProject.LayerControl.Functions.Identity,
                NeuralNetworksProject.LayerControl.Functions.RectifiedLinear
            };
            this.comboLayerAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLayerAct.FormattingEnabled = true;
            this.comboLayerAct.Location = new System.Drawing.Point(6, 42);
            this.comboLayerAct.Name = "comboLayerAct";
            this.comboLayerAct.Size = new System.Drawing.Size(120, 21);
            this.comboLayerAct.TabIndex = 7;
            //
            // numNeuronsLayer
            //
            this.numNeuronsLayer.Location = new System.Drawing.Point(6, 16);
            this.numNeuronsLayer.Maximum = new decimal(new int[] {1000, 0, 0, 0});
            this.numNeuronsLayer.Name = "numNeuronsLayer";
            this.numNeuronsLayer.Size = new System.Drawing.Size(120, 20);
            this.numNeuronsLayer.TabIndex = 6;
            //
            // LayerControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboLayerAct);
            this.Controls.Add(this.numNeuronsLayer);
            this.Controls.Add(this.lblLayer);
            this.Name = "LayerControl";
            this.Size = new System.Drawing.Size(150, 70);
            ((System.ComponentModel.ISupportInitialize)(this.numNeuronsLayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLayer;
        private System.Windows.Forms.ComboBox comboLayerAct;
        private System.Windows.Forms.NumericUpDown numNeuronsLayer;
    }
}
