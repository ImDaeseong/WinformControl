using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WinformControl.Controls
{
    public class RotatePictureBox : PictureBox
    {
        private Image _ImageDefault = null;
        public Image ImageDefault
        {
            get { return _ImageDefault; }
            set
            {
                _ImageDefault = value;
                Image = _ImageDefault;
            }
        }

        private int Angle;
        private int AngleStep = 5;
        private Timer tm = new Timer();

        private Graphics Graph = null;
        private Bitmap Bmp = null;
        private Graphics BmpGraph = null;
        private bool bInit = false;

        public RotatePictureBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            if (!DesignMode)
            {
                Graph = CreateGraphics();
                Graph.SmoothingMode = SmoothingMode.AntiAlias;

                tm.Interval = 10;
                tm.Tick += new EventHandler(tm_Tick);
            }
        }

        ~RotatePictureBox()
        {
            try
            {
                BmpGraph.Dispose();
                Bmp.Dispose();
                Graph.Dispose();
                tm.Stop();
            }
            catch { }
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            DrawRotateImage();
        }

        private void DrawRotateImage()
        {
            try
            {
                Init();

                if (Graph != null && Bmp != null && BmpGraph != null)
                {
                    BmpGraph.Clear(Color.Transparent);

                    if (ImageDefault != null)
                    {
                        BmpGraph.ResetTransform();//기볹 설정으로
                        BmpGraph.TranslateTransform(Width / 2, Height / 2);//위치 이동
                        BmpGraph.RotateTransform(Angle += AngleStep);//회전
                        BmpGraph.DrawImage(ImageDefault, -(Width / 2), -(Height / 2), Width, Height);//그리기
                        //Console.WriteLine("Angle:" + Angle);
                    }
                    Image = Bmp;
                }
            }
            catch { }
        }

        private void Init()
        {
            try
            {
                if (!bInit)
                {
                    Bmp = new Bitmap(Width, Height);
                    BmpGraph = Graphics.FromImage(Bmp);
                    BmpGraph.SmoothingMode = SmoothingMode.AntiAlias;
                    bInit = true;
                }
            }
            catch { }
        }

        public void RotatePictureBoxSetUnSet()
        {
            try
            {
                if (tm.Enabled)
                    tm.Enabled = false;
                else
                    tm.Enabled = true;
            }
            catch { }
        }

    }
}
