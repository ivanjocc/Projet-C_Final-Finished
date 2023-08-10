using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    abstract class Media
    {
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }

        // Constructor con parámetros
        protected Media(string title, DateTime publicationDate)
        {
            Title = title;
            PublicationDate = publicationDate;
        }
    }
}
