using System;
using System.Drawing;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ofdlgLoadData = new System.Windows.Forms.OpenFileDialog();
            this.tabpgUnsupervisedLearning = new System.Windows.Forms.TabPage();
            this.tabpgSupervisedLearning = new System.Windows.Forms.TabPage();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnSetNetwork = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chrtError = new AForge.Controls.Chart();
            this.gboxNetTopology = new System.Windows.Forms.GroupBox();
            this.pnlNetTopology = new System.Windows.Forms.Panel();
            this.dgviewLoadedData = new System.Windows.Forms.DataGridView();
            this.btnRemoveLayer = new System.Windows.Forms.Button();
            this.btnAddLayer = new System.Windows.Forms.Button();
            this.lblLearningRate = new System.Windows.Forms.Label();
            this.lblMomentum = new System.Windows.Forms.Label();
            this.txtbxLearningRate = new System.Windows.Forms.TextBox();
            this.txtbxMomentum = new System.Windows.Forms.TextBox();
            this.comboAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.tabpgSupervisedLearning.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.gboxNetTopology.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewLoadedData)).BeginInit();
            this.tabCtrlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdlgLoadData
            // 
            this.ofdlgLoadData.DefaultExt = "xls";
            this.ofdlgLoadData.Filter = "Excel Worksheets|*.xlsx|CSV Format|*.csv";
            this.ofdlgLoadData.Title = "Load Data";
            // 
            // tabpgUnsupervisedLearning
            // 
            this.tabpgUnsupervisedLearning.BackColor = System.Drawing.Color.Transparent;
            this.tabpgUnsupervisedLearning.Location = new System.Drawing.Point(4, 22);
            this.tabpgUnsupervisedLearning.Name = "tabpgUnsupervisedLearning";
            this.tabpgUnsupervisedLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgUnsupervisedLearning.Size = new System.Drawing.Size(823, 450);
            this.tabpgUnsupervisedLearning.TabIndex = 2;
            this.tabpgUnsupervisedLearning.Text = "UnsupervisedLearning";
            // 
            // tabpgSupervisedLearning
            // 
            this.tabpgSupervisedLearning.BackColor = System.Drawing.Color.Transparent;
            this.tabpgSupervisedLearning.Controls.Add(this.lblAlgorithm);
            this.tabpgSupervisedLearning.Controls.Add(this.comboAlgorithm);
            this.tabpgSupervisedLearning.Controls.Add(this.txtbxMomentum);
            this.tabpgSupervisedLearning.Controls.Add(this.txtbxLearningRate);
            this.tabpgSupervisedLearning.Controls.Add(this.lblMomentum);
            this.tabpgSupervisedLearning.Controls.Add(this.lblLearningRate);
            this.tabpgSupervisedLearning.Controls.Add(this.btnAddLayer);
            this.tabpgSupervisedLearning.Controls.Add(this.btnRemoveLayer);
            this.tabpgSupervisedLearning.Controls.Add(this.dgviewLoadedData);
            this.tabpgSupervisedLearning.Controls.Add(this.gboxNetTopology);
            this.tabpgSupervisedLearning.Controls.Add(this.pnlChart);
            this.tabpgSupervisedLearning.Controls.Add(this.btnTest);
            this.tabpgSupervisedLearning.Controls.Add(this.btnSetNetwork);
            this.tabpgSupervisedLearning.Controls.Add(this.btnTrain);
            this.tabpgSupervisedLearning.Controls.Add(this.btnLoadData);
            this.tabpgSupervisedLearning.Location = new System.Drawing.Point(4, 22);
            this.tabpgSupervisedLearning.Name = "tabpgSupervisedLearning";
            this.tabpgSupervisedLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgSupervisedLearning.Size = new System.Drawing.Size(823, 450);
            this.tabpgSupervisedLearning.TabIndex = 0;
            this.tabpgSupervisedLearning.Text = "Supervised Learning";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(455, 421);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.LoadDataClick);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(596, 421);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 23);
            this.btnTrain.TabIndex = 2;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.TrainNetrworkClick);
            // 
            // btnSetNetwork
            // 
            this.btnSetNetwork.Enabled = false;
            this.btnSetNetwork.Location = new System.Drawing.Point(455, 166);
            this.btnSetNetwork.Name = "btnSetNetwork";
            this.btnSetNetwork.Size = new System.Drawing.Size(95, 23);
            this.btnSetNetwork.TabIndex = 0;
            this.btnSetNetwork.Text = "Set Network";
            this.btnSetNetwork.UseVisualStyleBackColor = true;
            this.btnSetNetwork.Click += new System.EventHandler(this.SetNetworkClick);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(739, 421);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.TestNetworkClick);
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chrtError);
            this.pnlChart.Location = new System.Drawing.Point(3, 6);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(446, 438);
            this.pnlChart.TabIndex = 5;
            // 
            // chrtError
            // 
            this.chrtError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chrtError.Location = new System.Drawing.Point(0, 0);
            this.chrtError.Name = "chrtError";
            this.chrtError.RangeX = ((AForge.Range)(resources.GetObject("chrtError.RangeX")));
            this.chrtError.RangeY = ((AForge.Range)(resources.GetObject("chrtError.RangeY")));
            this.chrtError.Size = new System.Drawing.Size(446, 438);
            this.chrtError.TabIndex = 2;
            this.chrtError.Text = "Error Function";
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
            // dgviewLoadedData
            // 
            this.dgviewLoadedData.AllowUserToAddRows = false;
            this.dgviewLoadedData.AllowUserToDeleteRows = false;
            this.dgviewLoadedData.AllowUserToResizeColumns = false;
            this.dgviewLoadedData.AllowUserToResizeRows = false;
            this.dgviewLoadedData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgviewLoadedData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgviewLoadedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgviewLoadedData.Location = new System.Drawing.Point(455, 195);
            this.dgviewLoadedData.Name = "dgviewLoadedData";
            this.dgviewLoadedData.RowHeadersVisible = false;
            this.dgviewLoadedData.ShowEditingIcon = false;
            this.dgviewLoadedData.Size = new System.Drawing.Size(359, 220);
            this.dgviewLoadedData.TabIndex = 8;
            // 
            // btnRemoveLayer
            // 
            this.btnRemoveLayer.Enabled = false;
            this.btnRemoveLayer.Location = new System.Drawing.Point(556, 131);
            this.btnRemoveLayer.Name = "btnRemoveLayer";
            this.btnRemoveLayer.Size = new System.Drawing.Size(95, 23);
            this.btnRemoveLayer.TabIndex = 7;
            this.btnRemoveLayer.Text = "Remove Layer";
            this.btnRemoveLayer.UseVisualStyleBackColor = true;
            this.btnRemoveLayer.Click += new System.EventHandler(this.RemoveLayerClick);
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.Location = new System.Drawing.Point(455, 131);
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size(95, 23);
            this.btnAddLayer.TabIndex = 6;
            this.btnAddLayer.Text = "Add Layer";
            this.btnAddLayer.UseVisualStyleBackColor = true;
            this.btnAddLayer.Click += new System.EventHandler(this.AddLayerClick);
            // 
            // lblLearningRate
            // 
            this.lblLearningRate.Location = new System.Drawing.Point(657, 136);
            this.lblLearningRate.Name = "lblLearningRate";
            this.lblLearningRate.Size = new System.Drawing.Size(26, 18);
            this.lblLearningRate.TabIndex = 9;
            this.lblLearningRate.Text = "α = ";
            // 
            // lblMomentum
            // 
            this.lblMomentum.Location = new System.Drawing.Point(736, 136);
            this.lblMomentum.Name = "lblMomentum";
            this.lblMomentum.Size = new System.Drawing.Size(26, 18);
            this.lblMomentum.TabIndex = 9;
            this.lblMomentum.Text = "μ = ";
            // 
            // txtbxLearningRate
            // 
            this.txtbxLearningRate.Location = new System.Drawing.Point(689, 133);
            this.txtbxLearningRate.Name = "txtbxLearningRate";
            this.txtbxLearningRate.Size = new System.Drawing.Size(37, 20);
            this.txtbxLearningRate.TabIndex = 10;
            this.txtbxLearningRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LearningRateInsertionChangeText);
            // 
            // txtbxMomentum
            // 
            this.txtbxMomentum.Location = new System.Drawing.Point(768, 133);
            this.txtbxMomentum.Name = "txtbxMomentum";
            this.txtbxMomentum.Size = new System.Drawing.Size(37, 20);
            this.txtbxMomentum.TabIndex = 10;
            this.txtbxMomentum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LearningRateInsertionChangeText);
            // 
            // comboAlgorithm
            // 
            this.comboAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlgorithm.FormattingEnabled = true;
            this.comboAlgorithm.Location = new System.Drawing.Point(660, 169);
            this.comboAlgorithm.Name = "comboAlgorithm";
            this.comboAlgorithm.Size = new System.Drawing.Size(145, 21);
            this.comboAlgorithm.TabIndex = 11;
            this.comboAlgorithm.SelectedIndexChanged += new System.EventHandler(this.AlgorithmSelected);
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(556, 171);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(97, 13);
            this.lblAlgorithm.TabIndex = 12;
            this.lblAlgorithm.Text = "Training Algorithm :";
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Controls.Add(this.tabpgSupervisedLearning);
            this.tabCtrlMain.Controls.Add(this.tabpgUnsupervisedLearning);
            this.tabCtrlMain.Location = new System.Drawing.Point(13, 13);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(831, 476);
            this.tabCtrlMain.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 501);
            this.Controls.Add(this.tabCtrlMain);
            this.Name = "MainForm";
            this.Text = "Neural Network Examples";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramClosing);
            this.tabpgSupervisedLearning.ResumeLayout(false);
            this.tabpgSupervisedLearning.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            this.gboxNetTopology.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgviewLoadedData)).EndInit();
            this.tabCtrlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdlgLoadData;
        private System.Windows.Forms.TabPage tabpgUnsupervisedLearning;
        private System.Windows.Forms.TabPage tabpgSupervisedLearning;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.ComboBox comboAlgorithm;
        private System.Windows.Forms.TextBox txtbxMomentum;
        private System.Windows.Forms.TextBox txtbxLearningRate;
        private System.Windows.Forms.Label lblMomentum;
        private System.Windows.Forms.Label lblLearningRate;
        private System.Windows.Forms.Button btnAddLayer;
        private System.Windows.Forms.Button btnRemoveLayer;
        private System.Windows.Forms.DataGridView dgviewLoadedData;
        private System.Windows.Forms.GroupBox gboxNetTopology;
        private System.Windows.Forms.Panel pnlNetTopology;
        private System.Windows.Forms.Panel pnlChart;
        private AForge.Controls.Chart chrtError;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSetNetwork;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TabControl tabCtrlMain;
    }
}

