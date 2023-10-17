using System;
using System.Reflection;

namespace DummyDB_2
{
    class Program
    {
        static void Main()
        {
            ShowBooks();
        }
        static void ShowBooks()
        {
            List<Book> books = FillArrayBooks();
            List<Reader> readers = FillArrayReaders();
            List<ReaderBook> readersBooks = FillArrayReadersBooks();
            for (int i = 0; i < books.Count; i++)
            {
                uint readerId = 0;
                DateTime borrowThisBookTime = DateTime.MinValue;
                bool isBookTaken = CheckBorrowedBook(books[i].Id, readers, readersBooks, ref readerId, ref borrowThisBookTime);
                if (isBookTaken)
                {
                    string readerThisBook = TakeDataReader(readerId, readers);
                    Console.WriteLine(books[i].Id + " " + books[i].Author + " " + books[i].Title + " Взял: " + readerThisBook + " " + $"{borrowThisBookTime.ToString("d")}");
                }
                else
                {
                    Console.WriteLine(books[i].Id + " " + books[i].Author + " " + books[i].Title);
                }
            }

        }
        private static string TakeDataReader(uint readerId, List<Reader> readers)
        {
            for(int i = 1; i < readers.Count; i++)
            {
                if(readerId == readers[i].Id)
                {
                    return readers[i].Name + " ";
                }
            }
            return "";
        }
        private static bool CheckBorrowedBook(uint bookId, List<Reader> readers, List<ReaderBook> readersBooks, ref uint readerId, ref DateTime borrowTime)
        {
            for(int i = 0; i < readersBooks.Count; i++)
            {
                if (bookId == readersBooks[i].BookId && readersBooks[i].ReturnTime == DateTime.MinValue)
                {
                    borrowTime = readersBooks[i].BorrowTime;
                    readerId = readersBooks[i].ReaderId;
                    return true;
                }
            }
            return false;
        }
        private static List<Book> FillArrayBooks()
        {
            string[] booksData = File.ReadAllLines("..\\..\\..\\Data\\Book.csv");
            List<Book> books = new List<Book>();
            for (int i = 1; i < booksData.Length; i++)
            {
                books.Add(CsvParser.ParseBook(booksData[i]));
            }
            return books;
        }
        private static List<Reader> FillArrayReaders()
        {
            string[] readersData = File.ReadAllLines("..\\..\\..\\Data\\Reader.csv");
            List<Reader> readers = new List<Reader>();
            for(int i = 1; i < readersData.Length; i++)
            {
                readers.Add(CsvParser.ParseReader(readersData[i]));
            }
            return readers;
        }
        private static List<ReaderBook> FillArrayReadersBooks()
        {
            string[] readersBooksData = File.ReadAllLines("..\\..\\..\\Data\\ReadersBook.csv");
            List<ReaderBook> readersBooks = new List<ReaderBook>();
            for (int i = 1; i < readersBooksData.Length; i++)
            {
                readersBooks.Add(CsvParser.ParseReadersBooks(readersBooksData[i]));
            }
            return readersBooks;
        }
    }
}