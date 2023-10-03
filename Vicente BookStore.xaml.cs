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

namespace Angeles_991480645_Midterm
{

    public partial class Vicente_BookStore : Window
    {
        public Vicente_BookStore()
        {
            InitializeComponent();
        }

        //this function is for opening the main window/functionalities
        private void btnBookMan_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        //function to close the button
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
