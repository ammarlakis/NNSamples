using System;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Accord.IO;
using Accord.Math;
using Accord.Neuro;
using Accord.Neuro.ActivationFunctions;
using Accord.Neuro.Learning;
using Accord.Neuro.ActivationFunctions;

namespace NeuralNetworksProject
{
    public partial class MainForm : Form
    {
        private static readonly Collection<UserControl>  layersControls = new Collection<UserControl>();
        private ActivationNetwork actNet;
        private bool stopTraining = true;
        private Thread workerThread;
        private int epochs;
        private double errorLimit;
        private double[][] input;
        private double[][] target;
        private Methods selectedMethod = Methods.Backpropagation;

        private DistanceNetwork dstNet;
        private double[][] citiesMap;

        private readonly IActivationFunction[] Functions =
        {
            new LinearFunction(),
            new ThresholdFunction(),
            new SigmoidFunction(),
            new BipolarSigmoidFunction(),
            new BernoulliFunction(),
            new GaussianFunction(),
            new IdentityFunction(),
            new RectifiedLinearFunction()
        };

        private enum Methods
        {
            Backpropagation,
            LevenbergMarquardt
        }

        public MainForm()
        {
            InitializeComponent();
            var appSettings = ConfigurationManager.AppSettings;
            var layers = appSettings["Layers"].Split(',').Select(Int32.Parse).ToArray();
            for (int i = 0; i < layers.Length; i++)
            {
                AddLayerClick(null, null);
                var layer = (LayerControl) layersControls[i];
                if (i == 0)
                {
                    var comboBox = (ComboBox)layer.Controls[0];
                    comboBox.SelectedText = appSettings["ActivationFunction"];
                }
                var numBox = (NumericUpDown)layer.Controls[1];
                numBox.Value = layers[i];
            }
            var algo = (int)Enum.Parse(typeof(Methods), appSettings["TrainingAlgorithm"]);
            //this.comboAlgorithm.SelectedIndex = algo;
            this.txtbxLearningRate.Text = appSettings["LearningRate"];
            this.txtbxMomentum.Text = appSettings["Momentum"];
        }

        private void AddLayerClick(object sender, EventArgs e)
        {
            layersControls.Add(new LayerControl(layersControls.Count));
            pnlNetTopology.Controls.Add(layersControls[layersControls.Count-1] );
            if (layersControls.Count > 1)
            {
                btnRemoveLayer.Enabled = true;
            }
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
            var testString = ((TextBox)sender).Text;
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
            var inputLayerSize = int.Parse(((NumericUpDown)layersControls[0].Controls[1]).Text);
            var layers = new int[layersControls.Count - 1];
            for (int i = 1; i < layersControls.Count; i++)
            {
                layers[i - 1] = int.Parse(((NumericUpDown) layersControls[i].Controls[1]).Text);
            }
            var function = Functions[((ComboBox)layersControls[0].Controls[0]).SelectedIndex];
            actNet = new ActivationNetwork(function, inputLayerSize, layers);
        }

        private void LoadDataClick(object sender, EventArgs e)
        {
            ofdlgLoadData.InitialDirectory = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)) + "Documents";
            if (ofdlgLoadData.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable dataTable;
                    using (var csvReader = new CsvReader(new StreamReader(ofdlgLoadData.OpenFile()), false))
                    {
                        dataTable = csvReader.ToTable();
                        dataTable.Columns[0].ColumnName = "Input";
                        dataTable.Columns[1].ColumnName = "Target";
                    }

                    dgviewLoadedData.AutoGenerateColumns = true;
                    dgviewLoadedData.Columns.Clear();
                    dgviewLoadedData.DataSource = dataTable;
                    input = new double[dgviewLoadedData.RowCount][];
                    target = new double[dgviewLoadedData.RowCount][];
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = dgviewLoadedData[0, i].Value.ToString().Split(',').Select(double.Parse).ToArray();
                        target[i] = dgviewLoadedData[1, i].Value.ToString().Split(',').Select(double.Parse).ToArray();
                    }
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
            else if (input == null)
            {
                MessageBox.Show("You have to load the data first");
            }
            else
            {
                if (!stopTraining)
                {
                    stopTraining = true;
                    btnTrain.Text = "Train";
                }
                else
                {
                    if (ShowTrainingInputDialog())
                    {
                        this.chrtError.Series["Error"].Points.Clear();
                        btnTrain.Text = "Stop";
                        workerThread = new Thread(Train);
                        workerThread.Start();
                    }
                }
            }
        }

        private void Train()
        {
            stopTraining = false;
            //var errorsList = new ArrayList();
            ISupervisedLearning teacher;
            if (selectedMethod == Methods.Backpropagation)
            {
                teacher = new BackPropagationLearning(actNet)
                {
                    LearningRate = double.Parse(txtbxLearningRate.Text),
                    Momentum = double.Parse(txtbxMomentum.Text)
                };
            }
            else if (selectedMethod == Methods.LevenbergMarquardt)
            {
                teacher = new LevenbergMarquardtLearning(actNet)
                {
                    LearningRate = double.Parse(txtbxLearningRate.Text),
                };
            }
            else
            {
                throw new Exception("No method is selected");
            }
            var iterations = epochs;
            int percentage;
            while (!stopTraining)
            {
                var error = teacher.RunEpoch(input, target);
                if (stopTraining || (error <= errorLimit) || (iterations == 0))
                {
                    break;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    percentage = (int)Math.Round((double)(100 * (epochs - iterations)) / epochs);
                    this.progbarTrainingProcess.Value = percentage;
                    this.lblTrainingProcess.Text = "Training (" + percentage + " %" + ")";
                    chrtError.Series["Error"].Points.Add(new DataPoint(epochs - iterations, error));
                });
                iterations--;
            }
            stopTraining = true;
            this.Invoke((MethodInvoker) delegate
            {
                this.btnTrain.Text = "Train";
                this.progbarTrainingProcess.Value = 100;
                this.lblTrainingProcess.Text = "Done (100 %)";

                Save();
            });
        }

        private void Save()
        {
            const string filename = "Network.bin";
            actNet.Save(filename);
            MessageBox.Show($"Network saved to file '{filename}'.");
        }

        private void TestNetworkClick(object sender, EventArgs e)
        {
            if (this.actNet == null)
            {
                MessageBox.Show("You have to set the network first");
            }
            else if (input == null)
            {
                MessageBox.Show("You have to load the data first");
            }
            else
            {
                var colName = "Output " + (dgviewLoadedData.ColumnCount - 1);
                dgviewLoadedData.Columns.Add(colName, colName);
                for (int i = 0; i < Math.Min(input.Length, 100); i++)
                {
                    var output = actNet.Compute(input.GetRow(i));
                    var outputs = String.Join(",", output.Select(n => Math.Round((decimal)n, 4)));
                    var cell = new DataGridViewTextBoxCell { Value = outputs };
                    dgviewLoadedData["Output " + (dgviewLoadedData.ColumnCount - 2), i] = cell;
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
            var inputDialog = new TrainingInputDialog();
            if (inputDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.epochs = int.Parse(inputDialog.txtbxEpochs.Text);
                this.errorLimit = double.Parse(inputDialog.txtbxErrorLimit.Text);
                inputDialog.Dispose();
                return true;
            }
            inputDialog.Dispose();
            return false;
        }

        private void DataCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = dgviewLoadedData[0, i].Value.ToString().Split(',').Select(double.Parse).ToArray();
                target[i] = dgviewLoadedData[1, i].Value.ToString().Split(',').Select(double.Parse).ToArray();
            }
        }

        private void ShowNetworkDiagramClick(object sender, EventArgs e)
        {
            if (this.actNet == null)
            {
                MessageBox.Show("You have to set the network first");
            }
            else
            {
                var networkDiagramForm = new Form { Size = new Size(600, 400), AutoSize = false, AutoScroll = true };
                var netDiagram = new NetworkDiagram(actNet) { Dock = DockStyle.Fill };
                networkDiagramForm.Controls.Add(netDiagram);
                networkDiagramForm.ShowDialog(this);
            }
        }

        private void SetHopfieldNetworkClick(object sender, EventArgs e)
        {
            int cities, neurons;
            if ((int.TryParse(txtbxCities.Text, out cities) && int.TryParse(txtbxNeurons.Text, out neurons))
                && (cities > 0) && (neurons > 0))
            {
                this.dstNet = new DistanceNetwork(cities, neurons);
                citiesMap = new double[1][];
                citiesMap[0] = new double[cities];
                var r = new Random();
                for (int i = 0; i < cities; i++)
                {
                    citiesMap[0][i] = r.NextDouble();
                }
            }
            else
            {
                MessageBox.Show("Wrong input !");
            }
        }

        private void btnTrainHopfield_Click(object sender, EventArgs e)
        {
            int epochs;
            if ((int.TryParse(txtbxEpochs.Text, out epochs)) && (epochs > 0))
            {

            }
        }

    }
}
