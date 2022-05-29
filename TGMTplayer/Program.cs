using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ExamplePlayer;
using FFmpeg.AutoGen;
using TGMTplayer.Controls;

internal static class Program
{
    //public static Mutex Mutex;
    private static string _apppath = "";
    private static uint _previousExecutionState;
    public static WinFormsAppIdleHandler AppIdle;
    public static string phone = "0939.825.125";


    public static string AppPath
    {
        get
        {
            if (_apppath != "")
                return _apppath;
            _apppath = (Application.StartupPath.ToLower());
            _apppath = _apppath.Replace(@"\bin\debug", @"\").Replace(@"\bin\release", @"\");
            _apppath = _apppath.Replace(@"\bin\x86\debug", @"\").Replace(@"\bin\x86\release", @"\");
            _apppath = _apppath.Replace(@"\bin\x64\debug", @"\").Replace(@"\bin\x64\release", @"\");

            _apppath = _apppath.Replace(@"\\", @"\");

            if (!_apppath.EndsWith(@"\"))
                _apppath += @"\";
            Directory.SetCurrentDirectory(_apppath);
            return _apppath;
        }   
    }


    public static Mutex FfmpegMutex;
    
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {

        try
        {
            Application.EnableVisualStyles();            
            Application.SetCompatibleTextRenderingDefault(false);


            bool firstInstance = true;

            var me = Process.GetCurrentProcess();
            var arrProcesses = Process.GetProcessesByName(me.ProcessName);

            //only want to do this if not passing in a command

            if (arrProcesses.Length > 1)
            {
                firstInstance = false;
            }
            
            string executableName = Application.ExecutablePath;
            var executableFileInfo = new FileInfo(executableName);


            if (!firstInstance)
            {
                MessageBox.Show("Chương trình đã chạy, vui lòng kiểm tra trong Task Manager");
                Application.Exit();
                return;
            }


            FfmpegMutex = new Mutex();
            
            //Application.ThreadException += ApplicationThreadException;
           

            _previousExecutionState = NativeCalls.SetThreadExecutionState(NativeCalls.EsContinuous | NativeCalls.EsSystemRequired);


            AppIdle = new WinFormsAppIdleHandler();



            var mf = new MainForm();
            GC.KeepAlive(FfmpegMutex);
            
            Application.Run(mf);
            FfmpegMutex.Close();

            ffmpeg.avformat_network_deinit();


            if (_previousExecutionState != 0)
            {
                NativeCalls.SetThreadExecutionState(_previousExecutionState);
            }

        }
        catch (Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
        }
        
    }
}