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
using System.Windows.Shapes;
using WPFLayer.ViewModel;

namespace WPFLayer.View
{
    /// <summary>
    /// Logika interakcji dla klasy CustomerDetailsWindow.xaml
    /// </summary>
    public partial class CustomerDetailsWindow : Window
    {
        public CustomerDetailsWindow(int _id)
        {
            InitializeComponent();
            ListsViewModel _viewModel = new ListsViewModel(_id);
            this.DataContext = _viewModel;
        }
    }
}
