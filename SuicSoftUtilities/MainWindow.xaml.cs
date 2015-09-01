using MahApps.Metro.Controls;
using System;
using System.ComponentModel;
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
using System.IO;


namespace SuicSoftUtilities
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : MetroWindow
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();



        public MainWindow()
        {
            InitializeComponent();

            //A few boolean values act as 'ON (TRUE) / OFF (FALSE)' switches
            bool cookies = false;
            bool cache = false;
            bool history = false;
            bool pfdata = false;
            bool recentdownloads = false;

            //We subscribe to these events
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Here's the work:
            var IECache = Environment.SpecialFolder.InternetCache;
            var IECookies = Environment.SpecialFolder.Cookies;
            var IEHistory = Environment.SpecialFolder.History;
            var CrCookies = @"C:\Users\" + Environment.UserName.ToString() + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies";
            var CrFavicons = @"C:\Users\" + Environment.UserName.ToString() + @"\AppData\Local\Google\Chrome\User Data\Default\Favicons";
            var CrHistory = @"C:\Users\" + Environment.UserName.ToString() + @"\AppData\Local\Google\Chrome\User Data\Default\History";
            var CrCacheFolder = @"C:\Users\" + Environment.UserName.ToString() + @"\AppData\Local\Google\Chrome\User Data\Default\Cache";


            try {
                File.Delete(CrCookies);
                File.Delete(CrFavicons);
                File.Delete(CrHistory);
            }
            catch {
                MessageBox.Show("Bad Novice, SuicSoft Software Crashed");
            }
            
            
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Once our worker has completed
            
        }

        public void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
            useratpc.Text = Environment.UserName.ToString() + "@" + Environment.UserDomainName.ToString();
        }

        private void Novi_Click(object sender, RoutedEventArgs e)
        {
            //Run the worker!
            worker.RunWorkerAsync();
           
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            //Set the Cookies Boolean to True
            bool cookies = true;
        }
    }
}
