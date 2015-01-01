using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Neuro;

namespace NeuralNetworksProject
{
    public partial class NetworkDiagram : UserControl
    {
        private Graphics g;
        private bool done;
        private Pen pBlack, pGray;
        private Network network;
        private static Size circleSize = new Size(50, 50);
        private static int hStep = 120, vStep = 75;
        public NetworkDiagram(Network net)
        {
            InitializeComponent();
            Size = new Size(net.Layers.Length * hStep, net.Layers.Select(layer => layer.Neurons.Count()).Concat(new[] { 0 }).Max() * vStep);
            g = CreateGraphics();
            done = false;
            pBlack = new Pen(Color.Black);
            pGray = new Pen(Color.Gray);
            network = net;
        }

        private void NetworkDiagram_Paint(object sender, PaintEventArgs e)
        {
            DrawNetwork(network);
            if (! done)
            {
                done = false;
                Update();
            }
        }

        private Point[] DrawNetwork(Network net)
        {
            // Draw firstlayer input
            for (int ilayer = 0; ilayer < net.Layers.Count(); ilayer++)
            {
                for (int jneuron = 0; jneuron < net.Layers[ilayer].Neurons.Count(); jneuron++)
                {
                    //Draw Circle
                    g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(ilayer * hStep, jneuron * vStep), circleSize));
                    //Draw Lines to next layer
                }
            }
            return null;
        }
    }
}
