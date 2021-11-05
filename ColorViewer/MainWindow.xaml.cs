using ColorViewer.ViewModels;
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

namespace ColorViewer
{
    public partial class MainWindow : Window
    {
        ViewModel viewModel = null;
        public MainWindow()
        {
            viewModel = new ViewModel();
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
