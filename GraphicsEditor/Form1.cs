using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        Color shapeColor;
        Point startpoint = new Point(25, 25);
        Point endpoint = new Point(200, 200);
        private Point startPoint;

        private void OnPenColor(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                shapeColor = dlg.Color;
            }
        }

        private void onFileExit(object sender, EventArgs e)
        {
           var res= MessageBox.Show("Do you want to EXIT", "astro", MessageBoxButtons.YesNoCancel);

            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void OnShapeLine(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen mypen = new Pen(shapeColor, 4);
            g.DrawLine(mypen, startpoint, endpoint);
            //int width = endpoint.X - startpoint.X;
            //int height = endpoint.Y - startpoint.Y;
            //g.DrawRectangle(mypen, startpoint.X, startpoint.Y, width, height);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            this.startPoint = new Point(e.X, e.Y);
        }

        private void OnShapeRecatngle(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen mypen = new Pen(shapeColor, 5);
            g.DrawRectangle(mypen, 100, 200, 200, 100);

        }

        private void OnShapeSquare(object sender, EventArgs e)
        {
            
            Graphics g = this.CreateGraphics();
            Pen mypen = new Pen(shapeColor, 6);
            g.DrawRectangle(mypen, 200, 200, 200, 200);
        }
    }
}
