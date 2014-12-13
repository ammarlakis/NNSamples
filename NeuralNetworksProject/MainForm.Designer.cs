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
            this.dgviewLoadedData = new System.Windows.Forms.DataGridView();
            this.gboxNetTopology = new System.Windows.Forms.GroupBox();
            this.pnlNetTopology = new System.Windows.Forms.Panel();
            this.btnRemoveLayer = new System.Windows.Forms.Button();
            this.btnAddLayer = new System.Windows.Forms.Button();
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSetNetwork = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.pageLevenberg = new System.Windows.Forms.TabPage();
            this.pageHopfield = new System.Windows.Forms.TabPage();
            this.tabCtrlMain.SuspendLayout();
            this.pageBackPropagation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewLoadedData)).BeginInit();
            this.gboxNetTopology.SuspendLayout();
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
            this.pageBackPropagation.BackColor = System.Drawing.Color.Transparent;
            this.pageBackPropagation.Controls.Add(this.btnAddLayer);
            this.pageBackPropagation.Controls.Add(this.btnRemoveLayer);
            this.pageBackPropagation.Controls.Add(this.dgviewLoadedData);
            this.pageBackPropagation.Controls.Add(this.gboxNetTopology);
            this.pageBackPropagation.Controls.Add(this.pnlStatistics);
            this.pageBackPropagation.Controls.Add(this.btnTest);
            this.pageBackPropagation.Controls.Add(this.btnSetNetwork);
            this.pageBackPropagation.Controls.Add(this.btnTrain);
            this.pageBackPropagation.Controls.Add(this.btnLoadData);
            this.pageBackPropagation.Location = new System.Drawing.Point(4, 22);
            this.pageBackPropagation.Name = "pageBackPropagation";
            this.pageBackPropagation.Padding = new System.Windows.Forms.Padding(3);
            this.pageBackPropagation.Size = new System.Drawing.Size(823, 450);
            this.pageBackPropagation.TabIndex = 0;
            this.pageBackPropagation.Text = "BackPropagation";
            // 
            // dgviewLoadedData
            // 
            this.dgviewLoadedData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgviewLoadedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgviewLoadedData.Location = new System.Drawing.Point(455, 195);
            this.dgviewLoadedData.Name = "dgviewLoadedData";
            this.dgviewLoadedData.Size = new System.Drawing.Size(359, 220);
            this.dgviewLoadedData.TabIndex = 8;
            // 
            // gboxNetTopology
            // 
            this.gboxNetTopology.Controls.Add(this.pnlNetTopology);
            this.gboxNetTopology.Location = new System.Drawing.Point(455, 6);
            this.gboxNetTopology.Name = "gboxNetTopology";
            this.gboxNetTopology.Size = new System.Drawing.Size(362, 122);
            this.gboxNetTopology.TabIndex = 7;
            this.gboxNetTopology.TabStop = false;
            this.gboxNetTopology.Text = "Network Topology";
            // 
            // pnlNetTopology
            // 
            this.pnlNetTopology.AutoScroll = true;
            this.pnlNetTopology.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNetTopology.Location = new System.Drawing.Point(3, 16);
            this.pnlNetTopology.Name = "pnlNetTopology";
            this.pnlNetTopology.Size = new System.Drawing.Size(356, 103);
            this.pnlNetTopology.TabIndex = 0;
            // 
            // btnRemoveLayer
            // 
            this.btnRemoveLayer.Enabled = false;
            this.btnRemoveLayer.Location = new System.Drawing.Point(644, 134);
            this.btnRemoveLayer.Name = "btnRemoveLayer";
            this.btnRemoveLayer.Size = new System.Drawing.Size(95, 23);
            this.btnRemoveLayer.TabIndex = 7;
            this.btnRemoveLayer.Text = "Remove Layer";
            this.btnRemoveLayer.UseVisualStyleBackColor = true;
            this.btnRemoveLayer.Click += new System.EventHandler(this.RemoveLayerClick);
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.Location = new System.Drawing.Point(543, 134);
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size(95, 23);
            this.btnAddLayer.TabIndex = 6;
            this.btnAddLayer.Text = "Add Layer";
            this.btnAddLayer.UseVisualStyleBackColor = true;
            this.btnAddLayer.Click += new System.EventHandler(this.AddLayerClick);
            // 
            // pnlStatistics
            // 
            this.pnlStatistics.Location = new System.Drawing.Point(3, 6);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Size = new System.Drawing.Size(446, 438);
            this.pnlStatistics.TabIndex = 5;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(739, 421);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // btnSetNetwork
            // 
            this.btnSetNetwork.Enabled = false;
            this.btnSetNetwork.Location = new System.Drawing.Point(606, 166);
            this.btnSetNetwork.Name = "btnSetNetwork";
            this.btnSetNetwork.Size = new System.Drawing.Size(75, 23);
            this.btnSetNetwork.TabIndex = 0;
            this.btnSetNetwork.Text = "Set Network";
            this.btnSetNetwork.UseVisualStyleBackColor = true;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(606, 421);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 23);
            this.btnTrain.TabIndex = 2;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(461, 421);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            // 
            // pageLevenberg
            // 
            this.pageLevenberg.BackColor = System.Drawing.Color.Transparent;
            this.pageLevenberg.Location = new System.Drawing.Point(4, 22);
            this.pageLevenberg.Name = "pageLevenberg";
            this.pageLevenberg.Padding = new System.Windows.Forms.Padding(3);
            this.pageLevenberg.Size = new System.Drawing.Size(823, 450);
            this.pageLevenberg.TabIndex = 1;
            this.pageLevenberg.Text = "Levenberg";
            // 
            // pageHopfield
            // 
            this.pageHopfield.BackColor = System.Drawing.Color.Transparent;
            this.pageHopfield.Location = new System.Drawing.Point(4, 22);
            this.pageHopfield.Name = "pageHopfield";
            this.pageHopfield.Padding = new System.Windows.Forms.Padding(3);
            this.pageHopfield.Size = new System.Drawing.Size(823, 450);
            this.pageHopfield.TabIndex = 2;
            this.pageHopfield.Text = "Hopfield";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 501);
            this.Controls.Add(this.tabCtrlMain);
            this.Name = "MainForm";
            this.Text = "Neural Network Examples";
            this.tabCtrlMain.ResumeLayout(false);
            this.pageBackPropagation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgviewLoadedData)).EndInit();
            this.gboxNetTopology.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.TabPage pageBackPropagation;
        private System.Windows.Forms.TabPage pageLevenberg;
        private System.Windows.Forms.TabPage pageHopfield;
        private System.Windows.Forms.Button btnSetNetwork;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnAddLayer;
        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.GroupBox gboxNetTopology;
        private System.Windows.Forms.Panel pnlNetTopology;
        private System.Windows.Forms.DataGridView dgviewLoadedData;
        private System.Windows.Forms.Button btnRemoveLayer;
    }
}

