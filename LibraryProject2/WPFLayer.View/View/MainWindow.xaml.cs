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
using WPFLayer.Lib;
namespace WPFLayer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window, IWindow
    {
        private readonly ListsViewModel _vm = new ListsViewModel();
        public MainWindow()
        {
            InitializeComponent();
            Refresh();
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = _vm;
            _vm.ChildWindow = new Lazy<IWindow>(() => new BorrowBookWindow());
            _vm.ChildWindow2 = new Lazy<IWindow>(() => new BookAddWindow());
            _vm.ChildWindow3 = new Lazy<IWindow>(() => new CustomerAddWindow());

            _vm.ChildWindowBook = new Lazy<IWindow>(() => new BookDetailsWindow(_vm.BookId));
            _vm.ChildWindowBook2 = new Lazy<IWindow>(() => new BookEditWindow(_vm.BookId));
            _vm.ChildWindowCustomer = new Lazy<IWindow>(() => new CustomerDetailsWindow(_vm.CustomerId));
            _vm.ChildWindowCustomer2 = new Lazy<IWindow>(() => new CustomerEditWindow(_vm.CustomerId));
            _vm.ChildWindowBBook = new Lazy<IWindow>(() => new BorrowedBooksDetails(_vm.BorrowedBookId));
            _vm.ChildWindowBBook2 = new Lazy<IWindow>(() => new EditReturnDateWindow(_vm.BorrowedBookId));
         
            
          }
        public void Refresh()
        {
            custs.ItemsSource = _vm.GetCustomers();
            vbooks.ItemsSource = _vm.GetBooks();
           bbooks.ItemsSource = _vm.GetBorrowedBooks();
            DataContext = _vm;
        }
     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
