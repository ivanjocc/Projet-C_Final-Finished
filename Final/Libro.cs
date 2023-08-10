using System;

class Libro
{
    public string Title { get; set; } = ""; // Initialize with an empty string
    public string Author { get; set; } = ""; // Initialize with an empty string
    public DateTime PublicationDate { get; set; } // No need to initialize DateTime; it has a default value
}

////using System;

////class Libro
////{
////    public string Title { get; set; } = ""; // Initialize with an empty string
////    public string Author { get; set; } = ""; // Initialize with an empty string
////    public DateTime PublicationDate { get; set; } // No need to initialize DateTime; it has a default value
////}

//using Final;

//class Libro : Media, IAction
//{
//    public string Author { get; set; }
//    private List<Prestamo> prestamos; // Agrega esta línea
//    private Biblioteca biblioteca; // Agrega esta línea

//    private DataGridView dgvBorrowed;
//    private DataGridView dgvLibrary;

//    public Libro(string title, string author, DateTime publicationDate, List<Prestamo> prestamos, Biblioteca biblioteca)
//     : base(title, publicationDate)
//    {
//        Author = author;
//        this.prestamos = prestamos;
//        this.biblioteca = biblioteca;
//    }


//    public void Borrow()
//    {
//        Prestamo prestamo = new Prestamo(this, DateTime.Now);
//        prestamos.Add(prestamo);
//        biblioteca.RemoveMedia(this);
//        RefreshDataGridViews();
//    }

//    public void Return()
//    {
//        Prestamo prestamo = prestamos.FirstOrDefault(p => p.LibroPrestado == this);
//        if (prestamo != null)
//        {
//            prestamos.Remove(prestamo);
//            biblioteca.AddMedia(this);
//            RefreshDataGridViews();
//        }
//    }

//    private void RefreshDataGridViews()
//    {
//        // Refrescar los DataGridViews utilizando los nombres correctos
//        dgvLibrary.DataSource = null;
//        dgvLibrary.DataSource = biblioteca.Medias;

//        dgvBorrowed.DataSource = null;
//        dgvBorrowed.DataSource = prestamos;
//    }
//}


