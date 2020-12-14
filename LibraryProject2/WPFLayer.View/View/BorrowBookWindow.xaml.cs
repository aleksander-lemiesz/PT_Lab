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
using WPFLayer.Lib.ViewModel;
using WPFLayer.ViewModel;

namespace WPFLayer.View
{
    /// <summary>
    /// Logika interakcji dla klasy BorrowBookWindow.xaml
    /// </summary>
    public partial class BorrowBookWindow : Window, IWindow
    {
          public BorrowBookWindow()
        {
            InitializeComponent();
            BorrowBookActionViewModel _vm = new BorrowBookActionViewModel();
            clients.ItemsSource = _vm.GetCustomers();
            books.ItemsSource = _vm.GetBooks();
            DataContext = _vm;

        }
    }
}
