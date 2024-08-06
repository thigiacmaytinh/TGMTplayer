using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;

using Microsoft.Win32;
using System.Text;
using System.Net.Sockets;
using Timer = System.Timers.Timer;
using TGMTplayer.Utilities;
using TGMTplayer.Controls;
using TGMTplayer;
using System.Drawing.Imaging;

namespace ExamplePlayer
{
    public partial class MainForm : Form
    {
        
        public static float CpuUsage, CpuTotal;
        public static bool HighCPU;


        public static bool ShuttingDown = false;

        private PerformanceCounter _cpuCounter, _cputotalCounter;

        private PersistWindowState _mWindowState;
        private PerformanceCounter _pcMem;


        CameraFrame m_currentCameraFrame;

        private static string _counters = "";

        CameraFrame _cameraFrame;


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private readonly List<float> _cpuAverages = new List<float>();

        private static readonly object ThreadLock = new object();

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public MainForm()
        {
            InitializeComponent();
            _mWindowState = new PersistWindowState { Parent = this, RegistryPath = @"Software\tgmtplayer\startup" };
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainFormLoad(object sender, EventArgs e)
        {
        }      

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            ShuttingDown = true;


            if(_cameraFrame != null)
            {               
                _cameraFrame.Stop();
                _cameraFrame.Dispose();
            }


            _shuttingDown = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ShowForm(double opacity)
        {
            Activate();
            Visible = true;
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = _previousWindowState;
            }
            if (opacity > -1)
                Opacity = opacity;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            ShuttingDown = true;
            Close();
        }

        

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CameraFrames_Click(object sender, EventArgs e)
        {
            m_currentCameraFrame = (CameraFrame)sender;
            MouseEventArgs ee = (MouseEventArgs)e;

            if(ee.Button == MouseButtons.Right)
            {                
                ctxtMnu.Show(new Point(m_currentCameraFrame.parent.Location.X  + ee.Location.X,
                    m_currentCameraFrame.parent.Location.Y + ee.Location.Y + 20));
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DisplayCamera(string url, string resolution, Panel panelDisplay, int camIndex)
        {
            _cameraFrame = new CameraFrame(url, resolution);
            _cameraFrame.CamIndex = camIndex;

            _cameraFrame.Start();         
            _cameraFrame.parent = panelDisplay;
            _cameraFrame.Click += CameraFrames_Click;

            panelDisplay.Controls.Add(_cameraFrame);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string GenFilePath(string IN_or_OUT)
        {
            DateTime now = DateTime.Now;
            string dirPath = String.Format(@"{0}\{1}\{2}\", now.Year, now.ToString("MM"), now.Day);
            Directory.CreateDirectory(Program.AppPath + dirPath);

            string filePath = dirPath + DateTime.Now.ToString("yyyyMMdd_HHmmss_") + IN_or_OUT + ".jpg";
            return filePath;
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
                _cameraFrame.Stop();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            btn_start.Enabled = txt_url.Text != "";
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
            Bitmap bmp = m_currentCameraFrame.GetFrame();
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