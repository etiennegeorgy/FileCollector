using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Path = System.IO.Path;

namespace FileCollector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string sourceFolderPath;
        private string destFolderPath;
        private List<String> extensions = new List<string>();
        private bool enableCollectButton;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSource_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sourceFolderPath = fbd.SelectedPath;
                txtSource.Text = sourceFolderPath;
                txtDestination.Text = sourceFolderPath;
                btnCollect.IsEnabled = true;
            }
        }

        private void btnDestination_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                destFolderPath = fbd.SelectedPath;
                txtDestination.Text = destFolderPath;
            }
        }

        private void btnCollect_Click(object sender, RoutedEventArgs e)
        {
            string[] files = Directory.GetFiles(sourceFolderPath, "*.*", SearchOption.AllDirectories).Where(f => extensions.IndexOf(Path.GetExtension(f)) >= 0).ToArray();
            foreach (string s in files)
            {
                txtLog.Text += (s+"\r\n");
            }
        }

        private void Mkv_Checked(object sender, RoutedEventArgs e)
        {
            HandleChecked(sender as System.Windows.Controls.CheckBox);
        }

        private void Avi_Checked(object sender, RoutedEventArgs e)
        {
            HandleChecked(sender as System.Windows.Controls.CheckBox);
        }

        private void Mp4_Checked(object sender, RoutedEventArgs e)
        {
            HandleChecked(sender as System.Windows.Controls.CheckBox);
        }

        private void Mkv_Unchecked(object sender, RoutedEventArgs e)
        {
            HandleUnchecked(sender as System.Windows.Controls.CheckBox);
        }

        private void Avi_Unchecked(object sender, RoutedEventArgs e)
        {
            HandleUnchecked(sender as System.Windows.Controls.CheckBox);
        }

        private void Mp4_Unchecked(object sender, RoutedEventArgs e)
        {
            HandleUnchecked(sender as System.Windows.Controls.CheckBox);
        }

        void HandleChecked(System.Windows.Controls.CheckBox checkBox)
        {
            if (checkBox.IsChecked.Value)
            {
                extensions.Add("." + checkBox.Name);
            }
        }

        void HandleUnchecked(System.Windows.Controls.CheckBox checkBox)
        {
            if (!checkBox.IsChecked.Value)
            {
                int index = extensions.IndexOf("." + checkBox.Name);
                extensions.RemoveAt(index);
            }
        }

    }
}
