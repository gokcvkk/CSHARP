using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BookManagementSystem
{
    public partial class Form1 : Form
    {
        private List<Book> library = new List<Book>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            int year = (int)numYear.Value;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) ||
                title == "Kitap İsmi" || author == "Yazar İsmi")
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            Book newBook = new Book(title, author, year);
            library.Add(newBook);
            UpdateBookList();
        }

        private void UpdateBookList()
        {
            lstBooks.Items.Clear();
            foreach (var book in library)
            {
                lstBooks.Items.Add($"{book.Title} - {book.Author} - {book.Year}");
            }
        }

        private void txtTitle_Enter(object sender, EventArgs e)
        {
            if (txtTitle.Text == "Kitap İsmi")
            {
                txtTitle.Text = "";
                txtTitle.ForeColor = Color.Black;
            }
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                txtTitle.Text = "Kitap İsmi";
                txtTitle.ForeColor = Color.Gray;
            }
        }

        private void txtAuthor_Enter(object sender, EventArgs e)
        {
            if (txtAuthor.Text == "Yazar İsmi")
            {
                txtAuthor.Text = "";
                txtAuthor.ForeColor = Color.Black;
            }
        }

        private void txtAuthor_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                txtAuthor.Text = "Yazar İsmi";
                txtAuthor.ForeColor = Color.Gray;
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }
    }
}
