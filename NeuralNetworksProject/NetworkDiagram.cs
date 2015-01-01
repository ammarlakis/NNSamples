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
        private static Pen pBlack = new Pen(Color.Black), pGray = new Pen(Color.Gray);
        private static Brush bBlack = new SolidBrush(Color.Black), bGray = new SolidBrush(Color.Gray);
        private Network network;
        private static Size circleSize = new Size(50, 50);
        private static int hStep = 120, vStep = 75;
        public NetworkDiagram(Network net)
        {
            InitializeComponent();
            Size = new Size((net.Layers.Length + 2) * hStep, net.Layers.Select(layer => layer.Neurons.Count()).Concat(new[] { 0 }).Max() * vStep);
            g = CreateGraphics();
            done = false;
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
            for (int ilayer = 0; ilayer < net.Layers.Count(); ilayer++)
            {
                for (int jneuron = 0; jneuron < net.Layers[ilayer].Neurons.Count(); jneuron++)
                {
                    for (int input = 0; input < net.Layers[ilayer].InputsCount; input++)
                    {
                        // Draw line between two layers
                        g.DrawLine(pBlack,
                            new Point(ilayer*hStep + circleSize.Width, input*vStep + circleSize.Height/2),
                            new Point((1 + ilayer)*hStep, jneuron*vStep + circleSize.Height/2));
                    }
                    //Draw Neuron
                    g.FillEllipse(bBlack,
                        new Rectangle(new Point((1 + ilayer)*hStep, jneuron*vStep), circleSize));
                }
            }
            return null;
        }
    }
}
