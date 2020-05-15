using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonteCarlo
{
    public partial class Form1 : Form
    {
        Graphics g;
        double insideCircleCnt;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            insideCircleCnt = 0;
        }

        private void bthStart_Click(object sender, EventArgs e)
        {
            // Form2 f2 = new Form2(this);
            //f2.Owner = this;
            //f2.ShowDialog();
            insideCircleCnt = 0;
            g.Clear(Color.Black);
            Pen pen = new Pen(Color.Red);
            g.DrawEllipse(pen, 100, 65, (float)Convert.ToDouble(this.textBoxRad.Text), (float)Convert.ToDouble(this.textBoxRad.Text));
            g.DrawRectangle(pen, 100, 65, (float)Convert.ToDouble(this.textBoxRad.Text), (float)Convert.ToDouble(this.textBoxRad.Text));
            Random r = new Random();
            //DrawPoint(unchecked((int)r.Next(unchecked((int)2863311530), unchecked((int)3500570100))));

            //4294967295 - белый
            // 269488144 - минимум 2863311530
            for (int i = 0; i < Convert.ToDouble(this.textBoxCntThr.Text); i++)
            {
                Thread thread = new Thread(ThreadedDraw);
                thread.Start(unchecked((int)r.Next(unchecked((int)2863311530), unchecked((int)3500570100))));
                //Thread.Sleep(10);
                
            }
        }
        static object locker = new object();
        static Mutex mutexObj = new Mutex();
        void ThreadedDraw(object i)
        {
            //mutexObj.WaitOne();
            //lock (locker)
            //{

            for (int j = 0; j < Convert.ToDouble(this.textBoxCntP.Text); j++) // / Convert.ToDouble(this.textBoxCntThr.Text)
            {
                
                    DrawPoint(i, g);
                Thread.Sleep(Convert.ToInt32(this.textBoxSpeed.Text));
            }
            // }
            // mutexObj.ReleaseMutex();

        }
        void DrawPoint(object i, Graphics k)
        {
            //Graphics k;
            // g = panel1.CreateGraphics();
            k = panel1.CreateGraphics();
            Random r = new Random();
            Pen pen = new Pen(Color.FromArgb(unchecked((int)i)), 2);
            // Pen pen = new Pen(Color.FromArgb(unchecked((int)0x2864311530)), 3);
            int x = r.Next(100, 100 + Convert.ToInt32(this.textBoxRad.Text));
            int y = r.Next(65, 65 + Convert.ToInt32(this.textBoxRad.Text));
            k.DrawRectangle(pen, x, y, 1, 1);
            Thread.Sleep(1);
            if (InCircle(Convert.ToInt32(this.textBoxRad.Text), x, y)) insideCircleCnt++;
            //k.DrawRectangle(pen, 205, 5, 1, 1);
        }

        bool InCircle(double radius, double x, double y)
        {
            double xcentr = radius / 2 + 100;
            double ycentr = radius / 2 + 65;
            return (((x- xcentr) * (x- xcentr) + (y- ycentr) * (y- ycentr)) <= (radius/2) * (radius/2));
        }

        double RectangleAreaCalculate()
        {
            return 2* Convert.ToDouble(this.textBoxRad.Text) * 2 * Convert.ToDouble(this.textBoxRad.Text);
        }
        double Area()
        {
            return RectangleAreaCalculate() * (insideCircleCnt /Convert.ToDouble(this.textBoxCntThr.Text)) / Convert.ToDouble(this.textBoxCntP.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBoxSqr.Text = Area().ToString();
            // this.textBoxSqr2.Text = (insideCircleCnt / Convert.ToDouble(this.textBoxCntThr.Text)).ToString();
            this.textBoxSqr2.Text = (3.14 * Convert.ToDouble(this.textBoxRad.Text) * Convert.ToDouble(this.textBoxRad.Text)).ToString();
        }
    }
     
}
