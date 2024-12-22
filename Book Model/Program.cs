using System.Reflection;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Model
{
    public class Program
    {
        static void Main(string[] args)
        {
            string PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "books.json");
            string message = @"1.Add book
2.Show books
3.Search book
4.Delete book
5.Write to file
6.Read from file
0.Quit";
            Libary libary = new Libary();
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
                Console.WriteLine("books.json file created.");
            }
            else
            {
               /*
                string[] lines = File.ReadAllLines(PATH);

                foreach (string line in lines)
                {
                    // Deserialize each line into a Book object
                    Book book = JsonSerializer.Deserialize<Book>(line);
                    Libary.Books.Add(book);
                }

                */
               
            }
            Console.WriteLine($"Your example.txt path is here:{PATH}\n");
            Console.WriteLine(message);
            int input;
            do
            {
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        Console.WriteLine("Quiting..");
                        break;
                    case 1:
                        libary.AddBook();
                        break;
                    case 2:
                        libary.ShowAllBooks();
                        break;
                    case 3:
                        libary.SearchBook();
                        break;
                    case 4:
                        libary.DeleteBook();
                        break;
                    case 5:
                        Thread thread = new Thread(() => libary.WriteToFile(Console.ReadLine()));
                        thread.Start();
                        break;
                    case 6:
                        Thread thread2 = new Thread(() => libary.ReadFromFile(Console.ReadLine()));
                        
                        break;
                    default:
                        Console.WriteLine("Write valid number in the shown list");
                        break;
                }
            } while (input != 0);
        }
           
        }
    }
