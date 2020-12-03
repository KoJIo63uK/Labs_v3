using System;
using System.Collections.Generic;

namespace Lab_7
{
    // Сформировать односвязный список. 
    // Просмотреть в прямом направлении и вывести на консоль положительные значения его элементов.
    
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>{-10, 10, -2, 5};

            foreach (var item in list)
            {
                if (item > 0)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }
    }
}