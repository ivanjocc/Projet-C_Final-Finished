using System;
using System.Windows.Forms;

namespace Final
{
    public partial class Form1 : Form
    {
        private Biblioteca biblioteca = new Biblioteca();
        private List<Libro> librosPrestados = new List<Libro>();

        private List<Personne> personnes = new List<Personne>();


        public Form1()
        {
            InitializeComponent();

            // Initialize the DateTimePicker control for selecting publication date
            dateTimePickerPublicationDate.Format = DateTimePickerFormat.Short;
            dateTimePickerPublicationDate.Value = DateTime.Today;

            // Bind data to DataGridViews
            dataGridViewLibrary.DataSource = biblioteca.Libros;
            dataGridViewBorrowed.DataSource = librosPrestados;
            InitializeDataGridViewPersonnes();
        }

        private void InitializeDataGridViewPersonnes()
        {
            dataGridViewPersonnes.AutoGenerateColumns = false;

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            dataGridViewPersonnes.Columns.Add(nameColumn);
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Create a new book using the input values
            Libro newLibro = new Libro
            {
                Title = textBoxTitle.Text,
                Author = textBoxAuthor.Text,
                PublicationDate = dateTimePickerPublicationDate.Value
            };

            // Add the book to the library
            biblioteca.AddLibro(newLibro);

            // Refresh the DataGridView to reflect the changes
            dataGridViewLibrary.DataSource = null;
            dataGridViewLibrary.DataSource = biblioteca.Libros;

            // Clear input fields
            textBoxTitle.Clear();
            textBoxAuthor.Clear();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count > 0)
            {
                // Get the selected book
                Libro selectedLibro = (Libro)dataGridViewLibrary.SelectedRows[0].DataBoundItem;

                // Remove the book from the library
                biblioteca.RemoveLibro(selectedLibro);

                // Refresh the DataGridView to reflect the changes
                dataGridViewLibrary.DataSource = null;
                dataGridViewLibrary.DataSource = biblioteca.Libros;
            }
        }

        private void buttonBorrow_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count > 0)
            {
                // Get the selected book
                Libro selectedLibro = (Libro)dataGridViewLibrary.SelectedRows[0].DataBoundItem;

                // Add the selected book to the borrowed list
                librosPrestados.Add(selectedLibro);

                // Remove the book from the library
                biblioteca.RemoveLibro(selectedLibro);

                // Refresh both DataGridViews to reflect the changes
                RefreshDataGridViews();
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrowed.SelectedRows.Count > 0)
            {
                // Get the selected book
                Libro selectedLibro = (Libro)dataGridViewBorrowed.SelectedRows[0].DataBoundItem;

                // Add the selected book back to the library
                biblioteca.AddLibro(selectedLibro);

                // Remove the book from the borrowed list
                librosPrestados.Remove(selectedLibro);

                // Refresh both DataGridViews to reflect the changes
                RefreshDataGridViews();
            }
        }

        private void RefreshDataGridViews()
        {
            dataGridViewLibrary.DataSource = null;
            dataGridViewLibrary.DataSource = biblioteca.Libros;

            dataGridViewBorrowed.DataSource = null;
            dataGridViewBorrowed.DataSource = librosPrestados;

            dataGridViewPersonnes.DataSource = null;
            dataGridViewPersonnes.DataSource = personnes;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            string name = txtPersonName.Text;
            Personne newPerson = new Personne(name);
            personnes.Add(newPerson);

            RefreshDataGridViews(); // Actualizar DataGridViews

            // Limpiar campo de entrada
            txtPersonName.Clear();
            txtLastName.Clear();
        }

        private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            if (dataGridViewPersonnes.SelectedRows.Count > 0)
            {
                Personne selectedPersonne = (Personne)dataGridViewPersonnes.SelectedRows[0].DataBoundItem;
                personnes.Remove(selectedPersonne);
                RefreshDataGridViews();
            }
        }
    }
}

//using System;
//using System.Windows.Forms;

//namespace Final
//{
//    public partial class Form1 : Form
//    {
//        private Biblioteca biblioteca = new Biblioteca();
//        private List<Libro> librosPrestados = new List<Libro>();

//        private List<Libro> libros = new List<Libro>();
//        private List<Prestamo> prestamos = new List<Prestamo>();

//        public Form1()
//        {
//            InitializeComponent();

//            // Initialize the DateTimePicker control for selecting publication date
//            dateTimePickerPublicationDate.Format = DateTimePickerFormat.Short;
//            dateTimePickerPublicationDate.Value = DateTime.Today;

//            // Bind data to DataGridViews
//            dataGridViewLibrary.DataSource = biblioteca.Libros;
//            dataGridViewBorrowed.DataSource = librosPrestados;

//            // Configura las DataGridViews y otros elementos
//            InitializeDataGridViews();

//            RefreshDataGridViews();
//        }

//        private void InitializeDataGridViews()
//        {
//            // Configura las columnas de DataGridViewLibrary
//            dataGridViewLibrary.AutoGenerateColumns = false; // Desactiva la generaci�n autom�tica de columnas
//            dataGridViewLibrary.Columns.Add("Title", "Title");
//            dataGridViewLibrary.Columns.Add("Author", "Author");
//            dataGridViewLibrary.Columns.Add("PublicationDate", "Publication Date");

//            // Configura las columnas de DataGridViewBorrowed
//            dataGridViewBorrowed.AutoGenerateColumns = false; // Desactiva la generaci�n autom�tica de columnas
//            dataGridViewBorrowed.Columns.Add("Title", "Title");
//            dataGridViewBorrowed.Columns.Add("LoanDate", "Loan Date");
//        }

//        private void InitializeDataGridViewBorrowed()
//        {
//            dataGridViewBorrowed.AutoGenerateColumns = false;

//            DataGridViewColumn borrowedTitleColumn = new DataGridViewTextBoxColumn();
//            borrowedTitleColumn.DataPropertyName = "LibroPrestado.Title"; // Ajusta seg�n la estructura de tus clases
//            borrowedTitleColumn.HeaderText = "Borrowed Title";
//            dataGridViewBorrowed.Columns.Add(borrowedTitleColumn);

//            DataGridViewColumn loanDateColumn = new DataGridViewTextBoxColumn();
//            loanDateColumn.DataPropertyName = "LoanDate";
//            loanDateColumn.HeaderText = "Loan Date";
//            dataGridViewBorrowed.Columns.Add(loanDateColumn);
//        }

//        private void RefreshDataGridViews()
//        {
//            dataGridViewLibrary.DataSource = null;
//            dataGridViewLibrary.DataSource = biblioteca.Medias;

//            dataGridViewBorrowed.DataSource = null;
//            dataGridViewBorrowed.DataSource = prestamos;
//        }

//        private void buttonAdd_Click(object sender, EventArgs e)
//        {
//            string title = textBoxTitle.Text;
//            string author = textBoxAuthor.Text;
//            DateTime publicationDate = dateTimePickerPublicationDate.Value;

//            Libro newLibro = new Libro(title, author, publicationDate, prestamos, biblioteca);
//            libros.Add(newLibro);

//            RefreshDataGridViews(); // Refrescar las DataGridViews

//            // Limpiar campos de entrada
//            textBoxTitle.Clear();
//            textBoxAuthor.Clear();
//        }

//        private void buttonRemove_Click(object sender, EventArgs e)
//        {
//            if (dataGridViewLibrary.SelectedRows.Count > 0)
//            {
//                Libro selectedLibro = (Libro)dataGridViewLibrary.SelectedRows[0].DataBoundItem;
//                libros.Remove(selectedLibro);
//                RefreshDataGridViews();
//            }
//        }

//        private void buttonBorrow_Click(object sender, EventArgs e)
//        {
//            if (dataGridViewLibrary.SelectedRows.Count > 0)
//            {
//                Libro selectedLibro = (Libro)dataGridViewLibrary.SelectedRows[0].DataBoundItem;
//                selectedLibro.Borrow();

//                // Refresh both DataGridViews to reflect the changes
//                RefreshDataGridViews();
//            }
//        }

//        private void buttonReturn_Click(object sender, EventArgs e)
//        {
//            if (dataGridViewBorrowed.SelectedRows.Count > 0)
//            {
//                Prestamo selectedPrestamo = (Prestamo)dataGridViewBorrowed.SelectedRows[0].DataBoundItem;
//                selectedPrestamo.Return();

//                //Refresh both DataGridViews to reflect the changes
//                RefreshDataGridViews();
//            }
//        }
//    }
//}
