using System;

namespace DataStructures.LinkedList
{
    public class Cell
    {
        public int Value { get; set; }
        public Cell Next { get; set; }
    }

    public static class CellActions
    {
        public static void Print(Cell cell)
        {
            var head = cell;
            while (head != null)
            {
                Console.Write($"{head.Value} ");
                head = head.Next;
            }
            Console.WriteLine($"{Environment.NewLine}----------------------------------------");
        }

        public static void AddBeginning(ref Cell head, int value)
        {
            var newCell = new Cell { Value = value, Next = head };
            head = newCell;
        }

        public static void AddEnd(Cell head, int value)
        {
            var newCell = new Cell { Value = value };

            var previous = head;
            var next = head.Next;

            while (next != null)
            {
                previous = previous.Next;
                next = next.Next;
            }

            previous.Next = newCell;
        }

        public static void RemoveBeginning(ref Cell head)
        {
            var current = head;
            head = head.Next;
            current = null;
        }

        public static void RemoveEnd(Cell head)
        {
            var previous = head;
            var next = head.Next;

            while (next.Next != null)
            {
                previous = previous.Next;
                next = next.Next;
            }

            next = null;
            previous.Next = null;
        }
    }
}