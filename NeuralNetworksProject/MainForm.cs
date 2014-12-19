using System;
using System.Drawing;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Accord.IO;
using Accord.Math;
using Accord.Neuro.Learning;
using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace NeuralNetworksProject
{
    public partial class MainForm : Form
    {
        private static Collection<UserControl>  layersControls = new Collection<UserControl>();
        private ActivationNetwork actNet;
        private DataTable dataTable;
        private ArrayList errors = new ArrayList();
        private bool stopTraining = true;
        private Thread workerThread;
        private int epoches;
        private double errorLimit;
        private double[][] input;
        private double[][] target;
        private Methods selectedMethod = Methods.Backpropagation;
        private enum Methods
        {
            Backpropagation = 0, LevenbergMarquardt = 1
        }

        public MainForm()
         {
            InitializeComponent();
            this.comboAlgorithm.DataSource = Enum.GetValues(typeof(Methods));
            this.comboAlgorithm.SelectedItem = 0;
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
            ofdlgLoadData.InitialDirectory = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)) + "Documents";
            if (ofdlgLoadData.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataTable = new ExcelReader(ofdlgLoadData.OpenFile(),true,false).GetWorksheet("data");
                    dataTable.Columns[0].ColumnName = "Input";
                    dataTable.Columns[1].ColumnName = "Output";
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
            if (this.actNet == null)
            {
                MessageBox.Show("You have to set the network first");
            }
            else
            {
                input = new double[dgviewLoadedData.RowCount][];
                target = new double[dgviewLoadedData.RowCount][];
                for (int i = 0; i < input.Length; i++)
                {
                    input[i] = dgviewLoadedData[0, i].Value.ToString().Split(',').Select(item => double.Parse(item)).ToArray();
                    target[i] = dgviewLoadedData[1, i].Value.ToString().Split(',').Select(item => double.Parse(item)).ToArray();
                }
                if (!stopTraining)
                {
                    btnTrain.Text = "Train";
                    stopTraining = true;
                    while (!workerThread.Join(100))
                    {
                        Application.DoEvents();
                        workerThread = null;
                    }
                }
                else
                {
                    if (ShowTrainingInputDialog())
                    {
                        btnTrain.Text = "Stop";
                        workerThread = new Thread(new ThreadStart(Train));
                        workerThread.Start();
                    }
                }
            }
        }

        private void Train()
        {
            stopTraining = false;
            ArrayList errorsList = new ArrayList();
            ISupervisedLearning teacher;
            if (selectedMethod == Methods.Backpropagation)
            {
                teacher = new BackPropagationLearning(actNet);
                ((BackPropagationLearning)teacher).LearningRate = double.Parse(txtbxLearningRate.Text);
                ((BackPropagationLearning)teacher).Momentum = double.Parse(txtbxMomentum.Text);
            }
            else if (selectedMethod == Methods.Backpropagation)
            {
                teacher = new LevenbergMarquardtLearning(actNet);
                ((LevenbergMarquardtLearning)teacher).LearningRate = double.Parse(txtbxLearningRate.Text);
            }
            else
            {
                throw new Exception("No method is selected");
            }
            while (!stopTraining)
            {
                double error = teacher.RunEpoch(input, target);
                errorsList.Add(error);
                if (stopTraining || ((error <= errorLimit) && (epoches == 0)))
                {
                    break;
                }
                epoches--;
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
        private void TestNetworkClick(object sender, EventArgs e)
        {
            if (this.actNet == null)
            {
                MessageBox.Show("You have to set the network first");
            }
            else
            {
                double[][] input = new double[4][];
                input[0] = new double[] {0, 0};
                input[1] = new double[] {0, 1};
                input[2] = new double[] {1, 0};
                input[3] = new double[] {1, 1};
                double[][] output = new double[4][]
                {
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
        }


        private void ProgramClosing(object sender, FormClosingEventArgs e)
        {
            if ((workerThread != null) && workerThread.IsAlive)
            {
                stopTraining = true;
                while (!workerThread.Join(100))
                {
                    Application.DoEvents();
                }
            }
        }

        private void AlgorithmSelected(object sender, EventArgs e)
        {
            selectedMethod = (Methods) this.comboAlgorithm.SelectedItem;
            switch (selectedMethod)
            {
                case Methods.Backpropagation:
                    lblMomentum.Visible = true;
                    txtbxMomentum.Visible = true;
                    break;
                case Methods.LevenbergMarquardt:
                    lblMomentum.Visible = false;
                    txtbxMomentum.Visible = false;
                    break;
            }
        }
        public bool ShowTrainingInputDialog()
        {
            TrainingInputDialog inputDialog = new TrainingInputDialog();
            if (inputDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.epoches = int.Parse(inputDialog.txtbxEpoches.Text);
                this.errorLimit = double.Parse(inputDialog.txtbxErrorLimit.Text);
                inputDialog.Dispose();
                return true;
            }
            inputDialog.Dispose();
            return false;
        }
    }
}

