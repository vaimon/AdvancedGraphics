using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedGraphics
{
    enum DisplayType{ TRIANGLES, LINES, NET }

    public partial class FormPlotting : Form
    {
        Func<double, double, double> SelectedFunction { get; set; }
        DisplayType displayType;

        public FormPlotting()
        {
            InitializeComponent();
            displayType = DisplayType.TRIANGLES;
        }

        void setPBStyles(int selectedPBIndex)
        {
            pictureBox1.BorderStyle = selectedPBIndex == 1 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox1.BackColor = selectedPBIndex != 1 ? SystemColors.Control : SystemColors.ControlLight;

            pictureBox2.BorderStyle = selectedPBIndex == 2 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox2.BackColor = selectedPBIndex != 2 ? SystemColors.Control : SystemColors.ControlLight;

            pictureBox3.BorderStyle = selectedPBIndex == 3 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox3.BackColor = selectedPBIndex != 3 ? SystemColors.Control : SystemColors.ControlLight;

            pictureBox4.BorderStyle = selectedPBIndex == 4 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox4.BackColor = selectedPBIndex != 4 ? SystemColors.Control : SystemColors.ControlLight;

            pictureBox5.BorderStyle = selectedPBIndex == 5 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox5.BackColor = selectedPBIndex != 5 ? SystemColors.Control : SystemColors.ControlLight;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return x * x + y * y; };
            setPBStyles(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return Math.Sin(x) + Math.Cos(y); };
            setPBStyles(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return Math.Sin(x) * Math.Cos(y); };
            setPBStyles(5);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return 5 * (Math.Cos(x * x + y * y + 1) / (x * x + y * y + 1) + 0.1); };
            setPBStyles(1);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return (Math.Sin(x) + Math.Sin(y)) * Math.Pow(Math.Cos(x + y), 2); };
            setPBStyles(4);
        }

        private void rbTriangles_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTriangles.Checked)
            {
                displayType = DisplayType.TRIANGLES;
            }
        }

        private void rbLines_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLines.Checked)
            {
                displayType = DisplayType.LINES;
            }
        }

        private void rbNet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNet.Checked)
            {
                displayType = DisplayType.NET;
            }
        }
    }
}
