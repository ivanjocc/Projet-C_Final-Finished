using System.Collections.Generic;

class Biblioteca
{
    private List<Libro> libros = new List<Libro>();

    public List<Libro> Libros => libros;

    public void AddLibro(Libro libro)
    {
        libros.Add(libro);
    }

    public void RemoveLibro(Libro libro)
    {
        libros.Remove(libro);
    }
}

//using Final;
//using System.Collections.Generic;

//class Biblioteca
//{
//    private List<Libro> libros = new List<Libro>();

//    public List<Libro> Libros => libros;

//    private List<Media> medias = new List<Media>();

//    public List<Media> Medias
//    {
//        get { return medias; }
//    }

//    public void AddLibro(Libro libro)
//    {
//        libros.Add(libro);
//    }

//    public void RemoveLibro(Libro libro)
//    {
//        libros.Remove(libro);
//    }

//    private static List<Media> medios = new List<Media>();

//    public void AddMedia(Media media)
//    {
//        medias.Add(media);
//    }

//    public void RemoveMedia(Media media)
//    {
//        medias.Remove(media);
//    }
//}

