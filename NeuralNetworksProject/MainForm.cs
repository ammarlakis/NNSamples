using System;
using System.Drawing;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Accord.IO;
using Accord.Math;
using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge.Controls;

namespace NeuralNetworksProject
{
    public partial class MainForm : Form
    {
        private static Collection<UserControl>  layersControls = new Collection<UserControl>();
        private ActivationNetwork actNet;
        private DataTable dataTable;
        private ArrayList errors = new ArrayList();
        private AForge.Controls.Chart chrtError;
        private bool stopTraining = true;

        public MainForm()
         {
            InitializeComponent();
            chrtError.AddDataSeries("error", Color.Red, AForge.Controls.Chart.SeriesType.Line, 1);
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
                layers[i-1] = int.Parse(((NumericUpDown) layersControls[i].Controls[1]).Text);
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
            if (!stopTraining)
            {
                btnTrain.Text = "Train";
                stopTraining = true;
            }
            else
            {
                btnTrain.Text = "Stop";
                stopTraining = false;
                ArrayList errorsList = new ArrayList();
                BackPropagationLearning backPropagation = new BackPropagationLearning(actNet);
                backPropagation.LearningRate = double.Parse(txtbxLearningRate.Text);
                backPropagation.Momentum = double.Parse(txtbxMomentum.Text);
                int iterations = 20;
                double errorLimit = 0.2;
                double[][] input = new double[4][] {
											new double[] {0, 0},
											new double[] {0, 1},
											new double[] {1, 0},
											new double[] {1, 1}
										};
                double[][] output = new double[4][] {
											 new double[] {0},
											 new double[] {1},
											 new double[] {1},
											 new double[] {0}
										 };
                while (!stopTraining)
                {
                    double error = backPropagation.RunEpoch(input, output);
                    errorsList.Add(error);
                    if (stopTraining || ((error <= errorLimit) && (iterations == 0)))
                    {
                        break;
                    }
                    iterations--;
                }
                double[,] errors = new double[errorsList.Count, 2];
                for (int i = 0, n = errorsList.Count; i < n; i++)
                {
                    errors[i, 0] = i;
                    errors[i, 1] = (double)errorsList[i];
                }
                chrtError.RangeX = new Range(0, errorsList.Count - 1);
                chrtError.UpdateDataSeries("error", errors);
            }
        }

        private void TestNetworkClick(object sender, EventArgs e)
        {
            double[][] input = new double[4][];
            input[0] = new double[]{0,0};
            input[1] = new double[]{0,1};
            input[2] = new double[]{1,0};
            input[3] = new double[]{1,1};
            double[][] output = new double[4][] {
											 new double[] {0},
											 new double[] {1},
											 new double[] {1},
											 new double[] {0}
										 };

            for (int i = 0; i < input.Length; i++)
            {
                actNet.Compute(input.GetRow(i));
                MessageBox.Show(Math.Abs(output[i][0] - actNet.Output[0]).ToString());
            }
        }

        private void dgviewLoadedData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}

