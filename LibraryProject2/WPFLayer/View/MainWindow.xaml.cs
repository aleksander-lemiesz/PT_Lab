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
using WPFLayer.Model;
using WPFLayer.ViewModel;

namespace WPFLayer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private readonly ListsViewModel _viewModel = new ListsViewModel();
        public MainWindow()
        {
            InitializeComponent();

            custs.ItemsSource = _viewModel.GetCustomers();
            vbooks.ItemsSource = _viewModel.GetBooks();
            bbooks.ItemsSource = _viewModel.GetBorrowedBooks();
            DataContext = _viewModel;

        }
        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //var teamName = (e.Source as TextBlock).Text;
            MessageBox.Show("Hello World");
        }
    }
}
