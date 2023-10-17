using DummyDB_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDB_2
{
    public class Book
    {
        public uint Id { get; }
        public string Author { get; }
        public string Title { get; }
        public int YearOfPublication { get; }
        public uint ShelfNumber { get; }
        public uint CabinetNumber { get; }

        public Book(uint id, string author, string title, int yearOfPublication, uint shelfNumber, uint cabinetNumber)
        {
            Id = id;
            Author = author;
            Title = title;
            YearOfPublication = yearOfPublication;
            ShelfNumber = shelfNumber;
            CabinetNumber = cabinetNumber;
        }

        public Book()
        {
        }
    }
}