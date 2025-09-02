using System;
using System.Drawing;

using System.Globalization;
using System.IO;
using System.Windows.Forms;

using TGMTplayer.Utilities;
using TGMTplayer.Controls;
using TGMTplayer;
using System.Drawing.Imaging;

using TGMTcs;

namespace ExamplePlayer
{
    public partial class MainForm : Form
    {
        CameraWindow _CameraWindow;


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public MainForm()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainFormLoad(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().Init("TGMTplayer");
            txt_url.Text = TGMTregistry.GetInstance().ReadString(txt_url.Name);
        }      

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            if(_CameraWindow != null)
            {               
                _CameraWindow.Stop();
                _CameraWindow.Dispose();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            panel1.Width = this.Width / 2;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CameraWindows_Click(object sender, EventArgs e)
        {
            CameraWindow currentCameraWindow = (CameraWindow)sender;
            MouseEventArgs ee = (MouseEventArgs)e;

            if(ee.Button == MouseButtons.Right)
            {                
                ctxtMnu.Show(new Point(currentCameraWindow.parent.Location.X  + ee.Location.X,
                    currentCameraWindow.parent.Location.Y + ee.Location.Y + 20));
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DisplayCamera(string url, string resolution, Panel panelDisplay, int camIndex)
        {
            _CameraWindow = new CameraWindow(url, resolution);
            _CameraWindow.CamIndex = camIndex;

            _CameraWindow.Start();         
            _CameraWindow.parent = panelDisplay;
            _CameraWindow.Click += CameraWindows_Click;            

            panelDisplay.Controls.Add(_CameraWindow);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_start_Click(object sender, EventArgs e)
        {
            if(btn_start.Text == "Start")
            {
                btn_start.Text = "Stop";
                try
                {
                    string url = txt_url.Text;
                    string resolution = "1280x720";
                    DisplayCamera(url, resolution, panel1, 0);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                btn_start.Text = "Start";
                _CameraWindow.Stop();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            btn_start.Enabled = txt_url.Text != "";

            if (txt_url.Text == "")
                return;

            TGMTregistry.GetInstance().SaveValue(txt_url.Name, txt_url.Text);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnSnapshotHandler(object sender, CameraEventArgs e)
        {
            if (e.bmp == null)
            {
                //PrintError("Camera disconnected");
                return;
            }

            string folder = Program.AppPath + "snapshot\\";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fullpath = folder + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
            e.bmp.Save(fullpath, ImageFormat.Jpeg);

            Util.OpenUrl(fullpath);
        }

    
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void _takePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = _CameraWindow.GetFrame();
            if (bmp == null)
            {
                //PrintError("Camera disconnected");
                return;
            }

            string folder = Program.AppPath + "snapshot\\";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fullpath = folder + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
            bmp.Save(fullpath, ImageFormat.Jpeg);

            Util.OpenUrl(fullpath);
        }

        
    }
}