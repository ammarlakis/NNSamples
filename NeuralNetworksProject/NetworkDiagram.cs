using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public NetworkDiagram(Network net)
        {
            InitializeComponent();
            g = this.CreateGraphics();
            done = false;
            pBlack = new Pen(Color.Black);
            pGray = new Pen(Color.Gray);
            this.network = net;
        }

        private void NetworkDiagram_Paint(object sender, PaintEventArgs e)
        {
            DrawNetwork(this.network);
            if (! done)
            {
                done = false;
                this.Update();
            }
        }

        private Point[] DrawNetwork(Network net)
        {
            
        }
    }
}
