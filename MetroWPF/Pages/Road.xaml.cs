﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetroWPF.Pages
{
    /// <summary>
    /// Road.xaml 的交互逻辑
    /// </summary>
    public partial class Road : Page
    {
        string mcPath="";
        public Road()
        {
            InitializeComponent();
        }

        private void RoadChoose_Click(object sender, RoutedEventArgs e)
        {
            string PathTemp;
            FolderBrowserDialog browseMCFolder = new FolderBrowserDialog();
            browseMCFolder.Description = "选择\".minecraft\"文件夹";
            DialogResult browseResult = browseMCFolder.ShowDialog();
            if (browseResult != DialogResult.Cancel)
            {
                PathTemp = browseMCFolder.SelectedPath;
                if(PathTemp.Substring(PathTemp.Length - 10,10)==".minecraft")
                {
                    txtPath.Text = PathTemp;
                    mcPath = PathTemp;
                }
            }
        }

        private void FastGo_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(txtPath.Text);
            if(!dir.Exists)
            {
                System.Windows.Forms.MessageBox.Show("哎呀，这个文件夹不存在哟！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cleanMode = 0;//delare 0 as safe, 1 as deep, others as custom.
            if ((bool)radioDeep.IsChecked) {
                cleanMode = 1;
            }
            else
                cleanMode = 2;
            this.NavigationService.Navigate(new Pages.Scanning(cleanMode, txtPath.Text));
        }

        private void txtPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPath.Text.Length < 10)
            {
                FastGo.IsEnabled = false;
                return;
            }
            string last = txtPath.Text.Substring(txtPath.Text.Length - 10, 10);
            if (last == ".minecraft" || last == "minecraft\\")
                FastGo.IsEnabled = true;
            else
                FastGo.IsEnabled = false;
        }
    }
}
