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
    public partial class NetworkDiagram : UserControl
    {
        public NetworkDiagram()
        {
            InitializeComponent();
            Graphics g = this.CreateGraphics();
            g.DrawString("This is a test", new Font("Arial", 10), new SolidBrush(Color.Black), 20, 20);
        }
    }
}
