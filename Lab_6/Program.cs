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
            var myString = new MyString("My test string".ToCharArray());
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
        private readonly char[] _str;

        public MyString(char[] str)
        {
            _str = str;
        }

        public int GetCharIndex(char symbol)
        {
            var index = -1;
            for (int i = 0; i < _str.Length; i++)
            {
                if (_str[i] == symbol) index = i;
            }
            return index;
        }

        public MyString HighlightSubstring(string substring)
        {
            var sub = substring.ToCharArray();
            var highlightStart = "<highlight>".ToCharArray();
            var highlightEnd = "</highlight>";

            var subIndex = IndexOfSubstring(substring);
            var startIndex = subIndex;
            char[] newStr;
            
            if (startIndex > -1)
            {
                var lenth = _str.Length + highlightStart.Length + highlightEnd.Length;
                newStr = new char[lenth];
                for (int i = 0; i < startIndex; i++)
                {
                    newStr[i] = _str[i];
                }

                var tempIndex = 0;
                for (int i = startIndex; i < startIndex + highlightStart.Length; i++)
                {
                    newStr[i] = highlightStart[tempIndex];
                    tempIndex++;
                }

                startIndex += highlightStart.Length;
                
                tempIndex = 0;
                for (int i = startIndex; i < startIndex + sub.Length; i++)
                {
                    newStr[i] = sub[tempIndex];
                    tempIndex++;
                }
                startIndex += sub.Length;

                tempIndex = 0;
                for (int i = startIndex; i < startIndex + highlightEnd.Length; i++)
                {
                    newStr[i] = highlightEnd[tempIndex];
                    tempIndex++;
                }
                startIndex += highlightEnd.Length;

                tempIndex = subIndex + sub.Length;
                for (int i = startIndex; i < newStr.Length; i++)
                {
                    newStr[i] = _str[tempIndex];
                    tempIndex++;
                }

            }
            else
            {
                newStr = _str;
            }
            
            return new MyString(newStr);
        }

        public bool HasSubstring(string substring)
        {
            return IndexOfSubstring(substring) != -1;
        }

        private int IndexOfSubstring(string substring)
        {
            var sub = substring.ToCharArray();
            for (int i = 0; i < _str.Length; i++)
            {
                var inCount = 0;
                for (int j = 0; j < sub.Length; j++)
                {
                    if (i + j < _str.Length)
                    {
                        if (_str[i + j] == sub[j]) inCount++;
                    }
                }

                if (inCount == sub.Length) return i;
            }

            return -1;
        }

        public override string ToString()
        {
            return new string(_str);
        }
    }
}