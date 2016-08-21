﻿using System;
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
using static System.Windows.Navigation.NavigationService;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;

namespace MetroWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Uri uriMainFrm = new Uri("/Pages/MainFrm.xaml",UriKind.Relative);


        public MainWindow()
        {
            InitializeComponent();

            NavigationService frameNavServ = GetNavigationService(this.frame);

            //frameNavServ.Navigate(uriMainFrm);
            this.frame.Content = new MainFrm();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync("无反应", "因为现在的Nettoyager只有UI");
        }
    }
}
