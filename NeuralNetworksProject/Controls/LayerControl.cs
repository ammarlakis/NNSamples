using System.Drawing;
using System.Windows.Forms;

namespace NeuralNetworksProject
{
    public partial class LayerControl : UserControl
    {
        public enum Functions
        {
            Linear,
            Threshold,
            Threashold,
            Sigmoid,
            Bibolar,
            Bernoulli,
            Gaussian,
            Identity,
            RectifiedLinear
        }

        public LayerControl(int number)
        {
            InitializeComponent();
            this.Location = new Point(number * 150, this.Location.Y);
            this.lblLayer.Text = "Layer" + number.ToString();
            this.lblLayer.Name = this.lblLayer.Name + number.ToString();
            this.numNeuronsLayer.Name = this.numNeuronsLayer.Name + number.ToString();
            this.comboLayerAct.Name = this.comboLayerAct.Name + number.ToString();
        }
    }
}
