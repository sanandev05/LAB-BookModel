using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book_Model
{
    public class Libary
    {
        static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "books.json");

        public static List<Book> Books = new List<Book>();
        public void AddBook()
        {
            Console.WriteLine("Type :");
            string name = Console.ReadLine();
            Console.WriteLine("Author Name:");
            string author = Console.ReadLine();
            Console.WriteLine("Year :");
            int publicationYear = int.Parse(Console.ReadLine());
            Book book = new Book(name, author, publicationYear);
            Books.Add(book);
            Console.WriteLine("Succesfully Added");
            var JsonFormat = JsonSerializer.Serialize(book);
            string[] array = new string[1];
            array[0] = JsonFormat.ToString();
            File.AppendAllLines(path, array);

        }
        public void ShowAllBooks()
        {
            Console.WriteLine(File.ReadAllText(path));
        }
        public void SearchBook()
        {
            Console.WriteLine("Name :");
            string search = Console.ReadLine();
            string data = Books.Find(x => x.Name == search).Name;
            if (data != null)
            {
                Console.WriteLine(data);
            }
            else
            {
                Console.WriteLine("Book Not Found !");
            }
        }
        public void DeleteBook()
        {
            Console.WriteLine("Name :");
            string search = Console.ReadLine();
            Books.RemoveAll(x => x.Name==search);
            File.Delete(path);
            var JsonFormat = JsonSerializer.Serialize(Books);
            

            File.WriteAllText(path,JsonFormat);

        }
        public void WriteToFile(string path)
        {
            Console.WriteLine("path:");
            File.WriteAllText(path,JsonSerializer.Serialize(Books).ToString());
        }
        public void ReadFromFile(string path)
        {
            Console.WriteLine("path:");
            foreach (var book in File.ReadLines(path)) {
                Console.WriteLine(book);
            }
        }
    }
}
