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
using System.Windows.Shapes;
using WPFLayer.ViewModel;

namespace WPFLayer.View
{
    /// <summary>
    /// Logika interakcji dla klasy BookEditWindow.xaml
    /// </summary>
    public partial class BookEditWindow : Window
    {
        public BookEditWindow(int _id)
        {
            InitializeComponent();
            ListsViewModel _viewModel = new ListsViewModel(_id);
            DataContext = _viewModel;
        }
    }
}
