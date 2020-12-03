using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<ArrayItem>
            {
                new SummAfter(0, -3),
                new SummBefore(1, 1),
                new SummAfter(2, 1),
                new SummBefore(3, -1),
                new SummAfter(4, 1),
                new SummBefore(5,-3),
                new SummAfter(6, 1),
                new SummBefore(7, -3),
                new SummAfter(8, -3),
            };

            foreach (var item in list)
            {
                Console.Write($"Old value: {item.Value} | ");
                item.Action(list);
                Console.WriteLine($"New value: {item.Value}");
            }

            Console.ReadKey();
        }
    }

    public abstract class ArrayItem
    {
        protected readonly int Index;
        public int Value { get; protected set; }
        

        protected ArrayItem(int index, int value)
        {
            Index = index;
            Value = value;
        }

        public abstract void Action(ICollection<ArrayItem> collection);
    }

    public class SummAfter : ArrayItem
    {
        public SummAfter(int index, int value) : base(index, value)
        {
        }

        public override void Action(ICollection<ArrayItem> collection)
        {
            var list = collection.ToList();
            for (int i = Index + 1; i < collection.Count; i++)
            {
                if (list[i].Value > 0)
                {
                    Value += list[i].Value;
                }
            }
        }
    }
    
    public class SummBefore : ArrayItem
    {
        public SummBefore(int index, int value) : base(index, value)
        {
        }

        public override void Action(ICollection<ArrayItem> collection)
        {
            var list = collection.ToList();
            for (int i = Index - 1; i >= 0; i--)
            {
                if (list[i].Value > 0)
                {
                    Value += list[i].Value;
                }
            }
        }
    }
}