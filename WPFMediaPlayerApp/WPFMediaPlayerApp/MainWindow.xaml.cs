using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace WPFMediaPlayerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _videoPath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Video File(*.avi;*.mp4;*.mkv;*.wav;*.rmvb)|*.avi;*.mp4;*.mkv;*.wav;*.rmvb|All File(*.*)|*.*";

            if(dialog.ShowDialog().GetValueOrDefault())
            {
                //double x1 = image_Border.Margin.Left / MediaPlayer.ActualWidth;
                //double y1 = image_Border.Margin.Top / MediaPlayer.ActualHeight;
                //double x2 = (image_Border.Margin.Left + image_Border.ActualWidth) / MediaPlayer.ActualWidth;
                //double y2 = (image_Border.Margin.Top + image_Border.ActualHeight) / MediaPlayer.ActualHeight;

                _videoPath = dialog.FileName;
                //Process p = Process.Start(@"C:\Users\Love Qiong\Desktop\WPFMediaPlayerApp\WPFMediaPlayerApp\WPFMediaPlayerApp\bin\Debug\media_process.exe "+_videoPath+" 0.4 0.33 0.2 0.33");
                //System.Diagnostics.Process p = new System.Diagnostics.Process();
                //p.StartInfo.FileName = @"C:\Users\Love Qiong\Desktop\WPFMediaPlayerApp\WPFMediaPlayerApp\WPFMediaPlayerApp\bin\Debug\media_process.exe";
                //p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                //p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                //p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                //p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                //p.StartInfo.CreateNoWindow = false;//不显示程序窗口
                //p.Start();//启动程序
                //p.StandardInput.WriteLine(@"cd C:\Users\Love Qiong\Desktop\WPFMediaPlayerApp\WPFMediaPlayerApp\WPFMediaPlayerApp\bin\Debug ");
                //p.StandardInput.WriteLine(@"start media_process.exe " + _videoPath );

                //p.StandardInput.WriteLine("exit"); //若是运行时间短可加入此命令
                //p.WaitForExit();
                //p.Close();
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = @"C:\Users\Love Qiong\Desktop\WPFMediaPlayerApp\WPFMediaPlayerApp\WPFMediaPlayerApp\bin\Debug\media_process.exe"; //"输入完整的源路径"
                process.StartInfo.Arguments = "media_process.exe "+ _videoPath; //启动参数
                process.Start();


            }
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Source = new Uri(@"D:\tmp\tmp.mp4");

            MediaPlayer.Play();
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position = MediaPlayer.Position + TimeSpan.FromSeconds(20);
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position = MediaPlayer.Position - TimeSpan.FromSeconds(20);
        }

        private void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            // Get the lenght of the video
            int duration = MediaPlayer.NaturalDuration.TimeSpan.Seconds;
        }
        private void MediaPlayer_SizeChanged(object sender, RoutedEventArgs e)
        {

            //image_Border.Height = MediaPlayer.ActualHeight * 100.0 / 284.0;
            //image_Border.Width = MediaPlayer.ActualWidth * 100.0 / 552.0;
            
            //Thickness margin = new Thickness((MediaPlayer.ActualWidth - image_Border.Width) / 2, (MediaPlayer.ActualHeight - image_Border.Height) / 2, 0, 0);
            //image_Border.Margin = margin;
        }
    }
    
}
