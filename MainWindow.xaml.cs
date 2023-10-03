using System;
using System.CodeDom;
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
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Angeles_991480645_Midterm
{
    
    public partial class MainWindow : Window
    {
        //this is the list for the books
        private List<Book> _book;
        public MainWindow()
        {
            InitializeComponent();
            _book = new List<Book>();
        }

        //function for the btnSave
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            double price; //variable for the price 
            //this will check the price if its a number
            bool isPrice = double.TryParse(txtPrice.Text, out price); 

            int isbn; //variable for the ISBN
            //this will check the ISBN if its a number
            bool isISBN = int.TryParse(txtISBN.Text, out isbn);

            //if the price is not a number it will show the message box
            if (!isPrice)
            {
                MessageBox.Show("Please check your price!");
                txtPrice.Text = "";
                return;
            }
            //if the ISBN is not a number it will show the message box
            if (!isISBN)
            {
                MessageBox.Show("Please check your ISBN!");
                txtISBN.Text = "";
                return;
            }

            //goes thru the values inside the book
            foreach(var bk in _book)
            {
                //if isbn already exist this will return
                if(bk.ISBN == isbn)
                {
                    MessageBox.Show("ISBN exist already!");
                    txtISBN.Text = "";
                    return;
                }

            }
            
            //this saves the new books to the book list
            Book book = new Book(txtTitle.Text, genreCombo.Text, isbn, price);
            _book.Add(book); //adds the book
            ShowListBox();
            MessageBox.Show("New Book is Added");
            txtTitle.Text = "";
            genreCombo.Text = "";
            txtISBN.Text = "";
            txtPrice.Text = "";
        }

        //shows everything in the book 
        private void ShowListBox()
        {
            var result = from book in _book
                         select book;   
                lstBook.ItemsSource = result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           ShowListBox();
        }

        //this function is for searching the books using the Genre
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string genre = ((ComboBoxItem)comboGenre.SelectedItem).Content.ToString();
            var searchResults = _book.Where(book => book.Genre == genre).ToList();
            listBoxSearchResults.ItemsSource = searchResults;
        }

        //this function for update, updates the price by using the ISBN
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            foreach(var book in _book)
            {
                if(book.ISBN == int.Parse(txtISBN2.Text)){
                    book.Price = double.Parse(txtPrice2.Text);
                    MessageBox.Show("Book Updated");
                    ShowListBox();
                    return;
                    
                }
                
               
            }
            MessageBox.Show("Book not found!");
        }
        //function for closing the window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //function for going back to the landing page
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Vicente_BookStore vbookstore = new Vicente_BookStore();
            vbookstore.Show();
            Close();
        }
    }
}
