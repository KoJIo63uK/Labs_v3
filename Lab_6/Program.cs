using System;

namespace Labs_v6
{
    // Создать класс, описывающий строку символов. 
    // Реализовать операции поиска порядкового номера символа в строке, 
    // выделения подстроки и проверку принадлежности подстроки строке символов.
    
    class Program
    {
        static void Main(string[] args)
        {
            var myString = new MyString("My test string");
            var index = myString.GetCharIndex('e');
            var highlightedString = myString.HighlightSubstring("str");
            var hasWord = myString.HasSubstring("word");
            var hasTest = myString.HasSubstring("test");
            
            Console.WriteLine($"Index of char \'e\': {index}");
            Console.WriteLine($"Highlight string \"str\": {highlightedString}");
            Console.WriteLine($"Has substring \"word\": {hasWord}");
            Console.WriteLine($"Has substring \"test\": {hasTest}");

            Console.ReadKey();
        }
    }

    public class MyString
    {
        private readonly string _str;

        public MyString(string str)
        {
            _str = str;
        }

        public int GetCharIndex(char symbol)
        {
            return _str.IndexOf(symbol);
        }

        public string HighlightSubstring(string substring)
        {
            return _str.Replace(substring, $"<highlight>{substring}</highlight>");
        }

        public bool HasSubstring(string substring)
        {
            return _str.IndexOf(substring) > -1;
        }
    }
}