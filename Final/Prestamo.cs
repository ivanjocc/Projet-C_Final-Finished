using Final;

class Prestamo : Media, IAction
{
    public DateTime LoanDate { get; set; }
    public Libro LibroPrestado { get; set; } // Add

    public Prestamo(Libro libro, DateTime loanDate)
        : base(libro.Title, libro.PublicationDate)
    {
        LibroPrestado = libro; // Book
        LoanDate = loanDate;
    }

    public void Borrow()
    {
        // Do not need it
    }

    public void Return()
    {
        // Do not need it
    }
}
