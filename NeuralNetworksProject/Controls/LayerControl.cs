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
            this.lblLayer.Text = "Layer" + number;
            this.lblLayer.Name = this.lblLayer.Name + number;
            this.numNeuronsLayer.Name = this.numNeuronsLayer.Name + number;
            this.comboLayerAct.Visible = (number == 0);
            this.comboLayerAct.Name = this.comboLayerAct.Name + number;
        }
    }
}
