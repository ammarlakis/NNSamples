using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.IO;
using Accord.Math;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace NeuralNetworksProject
{
    public partial class MainForm : Form
    {
        private static Collection<UserControl>  layersControls = new Collection<UserControl>();
        private ActivationNetwork actNet;
        private DataTable dataTable;
        public MainForm()
         {
            InitializeComponent();
        }

        private void AddLayerClick(object sender, EventArgs e)
        {
            layersControls.Add(new LayerControl(layersControls.Count));
            pnlNetTopology.Controls.Add(layersControls[layersControls.Count-1] );
            btnRemoveLayer.Enabled = true;
            btnSetNetwork.Enabled = true;
        }

        private void RemoveLayerClick(object sender, EventArgs e)
        {
            layersControls.RemoveAt(layersControls.Count-1);
            pnlNetTopology.Controls.RemoveAt(layersControls.Count);
            if (layersControls.Count < 2)
            {
                btnRemoveLayer.Enabled = false;
                btnSetNetwork.Enabled = false;
            }
        }


        private void LearningRateInsertionChangeText(object sender, KeyEventArgs e)
        {
            String testString = ((TextBox)sender).Text;
            if (testString != "")
            {
                double result;
                if (!double.TryParse(((TextBox)sender).Text, out result))
                {
                    MessageBox.Show("Non-numeric insertion not allowed !");
                }
            }
        }

        private void SetNetworkClick(object sender, EventArgs e)
        {
            int inputLayerSize = int.Parse(((NumericUpDown)layersControls[0].Controls[1]).Text);
            int[] layers = new int[layersControls.Count - 1];
            for (int i = 1; i < layersControls.Count - 1; i++)
            {
                layers[i] = int.Parse(((NumericUpDown) layersControls[i].Controls[1]).Text);
            }
            actNet = new ActivationNetwork(new SigmoidFunction(),inputLayerSize,layers);
        }

        private void LoadDataClick(object sender, EventArgs e)
        {
            ofdlgLoadData.InitialDirectory = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            if (ofdlgLoadData.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show(ofdlgLoadData.FileName);
                    dataTable = new ExcelReader(ofdlgLoadData.OpenFile()).GetWorksheet("data");
                    dgviewLoadedData.DataSource = dataTable;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Couldn't get data!\n" + exception.Message);
                }
            }
            
        }

        private void TrainNetrworkClick(object sender, EventArgs e)
        {
            BackPropagationLearning backprob = new BackPropagationLearning(actNet);
            backprob.LearningRate = double.Parse(txtbxLearningRate.Text);
            backprob.Momentum = 0.0;
            int iteration = 5001;
            double hata = 0.0;
            //while (!dongu)
            //{
            //    hata = backprob.RunEpoch(this._inputData, this._outputData);
            //    iteration--;

            //    if (iteration < 1 || hata < 0.01)
            //        break;

            //}
            //MessageBox.Show("Hata oranı: " + hata);
        }

        private void TestNetworkClick(object sender, EventArgs e)
        {
            //for ( int i = 0; i < _inputData.Length; i++ )
            //{
            //   actNet.Compute( _inputData[i] );
            //   MessageBox.Show("Expected Output: " + _outputData[i][0] + "\n" + "Computed Value: " + actNet.Output[0] + "\n" + "Distance Value: " + Math.Abs( _outputData[i][0] - actNet.Output[0] ));
            //}
        }
    }
}
