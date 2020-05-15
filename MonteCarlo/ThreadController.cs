using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonteCarlo
{
    public class ThreadController
    {
        public PaintEventArgs e;
        public Form1 f1;
        public ThreadController(PaintEventArgs e, Form1 f1)
        {
            this.e = e;
            this.f1 = f1;
        }
        public void func()
        {
            DrawPoints(Convert.ToDouble(f1.textBoxCntP.Text));
        }

        public void DrawPoints(double pointCnt)
        {
            Random r = new Random();
            Random c = new Random();
            // Pen pen2 = new Pen(Color.FromArgb(c.Next(0, 255), c.Next(0, 255), c.Next(0, 255)));
            Pen pen2 = new Pen(Color.Green);
            //AutoResetEvent wh = (AutoResetEvent)handle;
            //double circle = 0;
            //double cntInsideC = 0; //Количество точек внутри круга

            for (double i = 0; i < pointCnt; i++)
            {
                float x = r.Next(10, 150 + Convert.ToInt32(f1.textBoxRad.Text));
                float y = r.Next(10, 150 + Convert.ToInt32(f1.textBoxRad.Text));

             e.Graphics.DrawEllipse(pen2, x, y, 1, 1);
            }
            // piList.Add((4 * circle) / (double)pointNumber);
            //  wh.Set();
        }
    }
}
