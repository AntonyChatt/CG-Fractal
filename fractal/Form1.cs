using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractal
{
    public partial class Form1 : Form
    {
        static Graphics holst;
        static Pen penW;
        public Form1()
        {
            InitializeComponent();
        }

        static int FractalKoh( PointF fir, PointF sec, PointF thi, int iteration)
        {
            if (iteration >0)
            {
                var fot = new PointF((sec.X+2*fir.X)/3, (sec.Y+2*fir.Y)/3);
                var fif = new PointF((2*sec.X+fir.X) / 3, (fir.Y+2*sec.Y) / 3);

                var ps = new  PointF((sec.X+fir.X)/2, (sec.Y+fir.Y)/2);
                var pn = new PointF((4 * ps.X - thi.X) / 3, (4 * ps.Y - thi.Y) / 3);

                holst.DrawLine(penW, fot, pn);
                holst.DrawLine(penW, fif, pn);
                holst.DrawLine(penW, fot, fif);

                FractalKoh(fot, pn, fif, iteration - 1);
                FractalKoh(pn, fif, fot, iteration - 1);
                FractalKoh(fir, fot, new PointF((2 * fir.X + thi.X) / 3, (2 * fir.Y + thi.Y) / 3), iteration - 1);
                FractalKoh(fif, sec, new PointF((2 * sec.X + thi.X) / 3, (2 * sec.Y + thi.Y) / 3), iteration - 1);
            }
            return iteration;
        }

        private void Draw(object sender, EventArgs e)
        {
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            penW = new Pen(Color.LightSteelBlue, 1);
            holst = CreateGraphics();
            holst.Clear(Color.SteelBlue);

            var Fpoint = new PointF(20, 175);
            var Spoint = new PointF(720, 175);
            var Tpoint = new PointF(370, 700);

            holst.DrawLine(penW, Fpoint, Spoint);
            holst.DrawLine(penW, Spoint, Tpoint);
            holst.DrawLine(penW, Tpoint, Fpoint);

            FractalKoh(Fpoint, Spoint, Tpoint, 5);
            FractalKoh(Spoint, Tpoint, Fpoint, 5);
            FractalKoh(Tpoint, Fpoint, Spoint, 5);
        }
    }
}
