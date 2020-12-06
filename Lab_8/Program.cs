using System;
namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyArray(5);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"Old value: {list[i].Value} | ");
                list[i].Action(list);
                Console.WriteLine($"New value: {list[i].Value}");
            }

            Console.ReadKey();
        }
    }

    public class MyArray
    {
        public ArrayItem this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }
        
        public int Count => _array.Length;
        
        private ArrayItem[] _array;

        public MyArray(int count)
        {
            _array = new ArrayItem[count];
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                if(i % 2 == 0)
                {
                    _array[i] = new SummAfter(i, random.Next(-10, 10));
                }
                else
                {
                    _array[i] = new SummBefore(i, random.Next(-10, 10));
                }
            }
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

        public abstract void Action(MyArray collection);
    }

    public class SummAfter : ArrayItem
    {
        public SummAfter(int index, int value) : base(index, value)
        {
        }

        public override void Action(MyArray collection)
        {
            var list = collection;
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

        public override void Action(MyArray collection)
        {
            var list = collection;
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