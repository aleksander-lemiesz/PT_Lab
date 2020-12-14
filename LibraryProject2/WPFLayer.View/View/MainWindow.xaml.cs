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
using WPFLayer.Lib.ViewModel;
using WPFLayer.Model;
using WPFLayer.View;
using WPFLayer.ViewModel;

namespace WPFLayer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window, IWindow
    {
        private readonly ListsViewModel _viewModel = new ListsViewModel();
        public MainWindow()
        {
            InitializeComponent();
            //Refresh();
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ListsViewModel _vm = (ListsViewModel)DataContext;
            //_vm.ChildWindow = new Lazy<IWindow>(() => new EditReturnDateWindow(1));
           // _vm.MessageBoxShowDelegate = text => MessageBox.Show(text, "Button interaction", MessageBoxButton.OK);
        }
        public void Refresh()
        {
            //custs.ItemsSource = _viewModel.GetCustomers();
            //vbooks.ItemsSource = _viewModel.GetBooks();
          // bbooks.ItemsSource = _viewModel.GetBorrowedBooks();
            DataContext = _viewModel;
        }
     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
