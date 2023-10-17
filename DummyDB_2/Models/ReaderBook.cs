using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDB_2
{
    public class ReaderBook
    {
        public uint ReaderId { get; }
        public uint BookId { get; }
        public DateTime BorrowTime { get; }
        public DateTime ReturnTime { get; }
        public ReaderBook(uint readerId, uint bookId, DateTime borrowTime, DateTime returnTime) 
        {
            ReaderId = readerId;
            BookId = bookId;
            BorrowTime = borrowTime;
            ReturnTime = returnTime;
        }
    }
}
