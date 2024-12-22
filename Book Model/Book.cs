using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public class Book
    {

        public static int ID { get; private set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublictionYear { get; set; }

        public Book(string name,string author,int pubYear)
        {
            ID++;
            Name = name;
            Author = author;
            PublictionYear = pubYear;
        }
    }
}
