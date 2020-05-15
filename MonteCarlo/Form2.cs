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
    public partial class Form2 : Form
    {
        Form1 f1 = new Form1();
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f1)
        {

            this.Owner = f1;
            this.f1 = f1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        static List<EventWaitHandle> handles = new List<EventWaitHandle>();
        private void FormGraphic_Paint(object sender, PaintEventArgs e)
        {
            DrawCircle(e, f1);
            ThreadController controller = new ThreadController(e, f1);
            for (double i = 0; i < Convert.ToDouble(f1.textBoxCntThr.Text); i++)
            {
                EventWaitHandle handle = new AutoResetEvent(false);
                handles.Add(handle);
                Thread th1 = new Thread(controller.func);
                th1.Start();
               // DrawPoints(e, f1, Convert.ToDouble(f1.textBoxCntP.Text));
            }
            //WaitHandle.WaitAll(handles.ToArray());
        }
        void DrawCircle(PaintEventArgs e, Form1 f)
        {
            Pen pen = new Pen(Color.Red);
            e.Graphics.DrawEllipse(pen, 150, 30, (float)Convert.ToDouble(f.textBoxRad.Text), (float)Convert.ToDouble(f.textBoxRad.Text));
            e.Graphics.DrawRectangle(pen, 150, 30, (float)Convert.ToDouble(f.textBoxRad.Text), (float)Convert.ToDouble(f.textBoxRad.Text));
            
        }
        void ThreadDraw(PaintEventArgs e)
        {

        }
        

        //Проверяет, находится ли точка внутри круга
        static bool InCircle(double radius, double x, double y)
        {
            return ((x * x + y * y) <= radius * radius);
        }
        //Проверяет, находится ли точка внутри квадрата
        static bool InRectangle(double x, double y, double a1x, double a1y, double a2x, double a2y)
        {
            return x >= a1x && x <= a2x && y >= a2y && y <= a2y;
        }
    }
}
