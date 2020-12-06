using System;

namespace Lab_7
{
    // Сформировать односвязный список. 
    // Просмотреть в прямом направлении и вывести на консоль положительные значения его элементов.
    
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList(10);
            Console.WriteLine(list);
            list.DoActions();

            Console.ReadKey();
        }
    }
    
    //Намеренно не добавляю элементы в массив так как односвязанный список и массив две разные структуры
    //данных и нужно выбирать массив или список. Я выбрал список (он больше подходит под критерии задания),
    //осуществляю свою реализацию односвязонного списка.
    public class MyList
    {
        private Item _root;
        private Item _end;
        public int Count { get; private set; }

        public MyList(int count)
        {
            GenerateRandomItems(count);
        }

        public void Add(Item item)
        {
            if (_root == null)
            {
                _root = item;
                _end = item;
            }
            else
            {
                _end.Next = item;
                _end = item;
            }

            Count++;
        }

        public void DoActions()
        {
            if (_root != null)
            {
                var item = _root;
                do
                {
                    item.Action();
                    item = item.Next;
                } while (item != null);
            }
        }

        private void GenerateRandomItems(int count)
        {
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                Add(new Item(random.Next(-10, 10)));
            }
        }

        public override string ToString()
        {
            var str = "";
            if (_root != null)
            {
                var item = _root;
                do
                {
                    str += $"{item.Value} ";
                    item = item.Next;
                } while (item != null);
            }

            return str;
        }
    }

    public class Item
    {
        public int Value { get; set; }

        public Item Next { get; set; }

        public Item(int value)
        {
            Value = value;
            Next = null;
        }

        public void Action()
        {
            if(Value >  0) Console.WriteLine(Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}