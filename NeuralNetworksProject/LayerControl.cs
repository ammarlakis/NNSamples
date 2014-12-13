using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworksProject
{
    public partial class LayerControl : UserControl
    {
        public LayerControl(int number)
        {
            InitializeComponent();
            this.Location = new Point(this.Location.X + number * 150, this.Location.Y);
            this.lblLayer.Text = "Layer" + number.ToString();
            this.lblLayer.Name = this.lblLayer.Name + number.ToString();
            this.numNeuronsLayer.Name = this.numNeuronsLayer.Name + number.ToString();
            this.comboLayerAct.Name = this.comboLayerAct.Name + number.ToString();
        }
    }
}
