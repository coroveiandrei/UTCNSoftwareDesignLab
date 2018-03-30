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
using BusinessLogic.Contracts;
using BusinessLogic.Contracts.Services;
using BusinessLogic.Services;
using Microsoft.Practices.ServiceLocation;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBookService bookService;
        public MainWindow()
        {
            InitializeComponent();
            //bookService = new BookService();
            bookService = ServiceLocator.Current.GetInstance<IBookService>();
            LoadData();
        }

        private void LoadData()
        {
            this.dgBooks.ItemsSource = bookService.GetAll();
        }

    }
}
