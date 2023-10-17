using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDB_2
{
    public class CsvParser
    { 
        public static Book ParseBook(string book)
        {
            string[] bookData = book.Split(';');
            uint id = TryParseBookUInt(bookData[0], 0);
            string author = bookData[1];
            string title = bookData[2];
            int yearOfPublication = TryParseBookInt(bookData[3]);
            uint shelfNumber = TryParseBookUInt(bookData[4], 4);
            uint cabinetNumber = TryParseBookUInt(bookData[5],5);
            return new Book(id,author,title,yearOfPublication,shelfNumber,cabinetNumber);
        }
        public static Reader ParseReader(string reader)
        {
            string[] readerData = reader.Split(";");
            uint id = TryParseReaderInt(readerData[0]);
            string name = readerData[1];
            return new Reader(id, name);
        }
        public static ReaderBook ParseReadersBooks(string readersBooks)
        {
            string[] readersBooksData = readersBooks.Split(";");
            uint readerId = TryParseReadersBooksUInt(readersBooksData[0],0);
            uint bookId = TryParseReadersBooksUInt(readersBooksData[1], 1);
            DateTime borrowTime = TryParseBorrowTime(readersBooksData[2]);
            if (readersBooksData.Length != 4)
            {
                return new ReaderBook(readerId, bookId, borrowTime, DateTime.MinValue);
            }
            DateTime returnTime = TryParseReturnTime(readersBooksData[3]);
            return new ReaderBook(readerId, bookId, borrowTime, returnTime);
        }
        public static string[] ParseTitle(string titles)
        {
            string[] parsedTitles = titles.Split(";");
            return parsedTitles;
        }
        private static uint TryParseBookUInt(string value, int numberOfColumn)
        {
            uint checkedType;
            if(!uint.TryParse(value, out checkedType) && value != "")
            {
                switch(numberOfColumn)
                {
                    case 0:
                        throw new Exception($"Данные о книге неверны: столбец 'Id' ({value})");
                    case 4:
                        throw new Exception($"Данные о книге неверны: столбец 'ShelfNumber' ({value})");
                    case 5:
                        throw new Exception($"Данные о книге неверны: столбец 'CaseNumber' ({value})");
                }
            }
            return checkedType;

        }
        private static int TryParseBookInt(string value)
        {
            int checkedType;
            if(!int.TryParse(value, out checkedType) && value != "")
            {
                throw new Exception($"Данные о книге неверны: столбец 'YearOfPublication' ({value})");
            }
            return checkedType;
        }
        private static uint TryParseReaderInt(string value)
        {
            uint checkedType;
            if(!uint.TryParse(value, out checkedType) && value != "")
            {
                throw new Exception($"Данные о читателе неверны: столбец 'Int' ({value})");
            }
            return checkedType;
        }
        private static uint TryParseReadersBooksUInt(string value, int numberOfColumn)
        {
            uint checkedType;
            if(!uint.TryParse(value, out checkedType) && value != "")
            {
                switch(numberOfColumn) 
                {
                    case 0:
                        throw new Exception($"Данные о читателе книги неверны: столбец 'ReaderId' ({value})");
                    case 1:
                        throw new Exception($"Данные о читателе книги неверны: столбец 'BookId' ({value})");
                }
            }
            return checkedType;
        }
        private static DateTime TryParseBorrowTime(string value)
        {
            DateTime checkedType;
            if(!DateTime.TryParse(value, out checkedType) && value != "")
            {
                throw new Exception($"Данные о читателе книги неверны: столбец 'BorrowTime' ({value})");
            }
            return checkedType;
        }
        private static DateTime TryParseReturnTime(string value)
        {
            DateTime checkedType;
            if(!DateTime.TryParse(value, out checkedType) && value != "")
            {
                throw new Exception($"Данные о читателе книги неверны: столбец 'ReturnTime' ({value})");
            }
            return checkedType;
        }
    }
}
