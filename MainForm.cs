using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonteCarlo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            simulator = new Simulator();
            result = new SimulationResult();
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
        }
        Simulator simulator;
        SimulationResult result;
        Func<double, double, bool> func;
        private void button1_Click(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                var tmp = new List<Point>();
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    var p = simulator.Execute();
                    tmp.Add(new Point(p.X, p.Y));
                }
                result.Points.AddRange(tmp);
                switch (comboBox1.SelectedIndex)
                {
                    case -1:
                        func = (x, y) => x * x + y * y < 1.0;
                        break;
                    case 0:
                        func = (x, y) => x * x + y * y < 1.0;
                        break;
                    case 1:
                        func = (x, y) => Math.Pow(x, 2.0/3) + Math.Pow(y, 2.0/3) < 1.0;
                        break;
                    case 2:
                        func = (x, y) => x + y < 1;
                        break;
                    default:
                        func = (x, y) => x * x + y * y < 1.0;
                        break;
                }
                foreach (var p in tmp)
                {
                    p.Func = func;
                    if (p.Judge())
                    {
                        chart1.Series[1].Points.AddXY(p.X, p.Y);
                    }
                    else
                    {
                        chart1.Series[0].Points.AddXY(p.X, p.Y);
                    }
                }
                var trueCount = result.Trues().Count();
                var falseCount = result.Falses().Count();
                label1.Text = trueCount.ToString();
                label2.Text = falseCount.ToString();
                label3.Text = (4.0 * trueCount / (trueCount + falseCount)).ToString();
            }));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            result.Points.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
        }
    }
}
