using System;
using DataStructures.LinkedList;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Single Linked List
            var main = new Cell { Value = 23, Next = new Cell { Value = 17, Next = new Cell { Value = 8, Next = new Cell { Value = 44 } } } };
            CellActions.Print(main);

            CellActions.AddBeginning(ref main, 55);
            CellActions.Print(main);

            CellActions.AddEnd(main, 77);
            CellActions.Print(main);

            CellActions.RemoveBeginning(ref main);
            CellActions.Print(main);

            CellActions.RemoveEnd(main);
            CellActions.Print(main); 
            #endregion

            Console.ReadKey();
        }
    }
}
