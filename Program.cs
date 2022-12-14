using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charArray = new []{'A','B','C','D'};

            IEnumerable<String> variants = GetAllSequences(charArray);
            
            foreach(string variant in variants)
            {
                Console.WriteLine(variant);
            }
        }

        static IEnumerable<String> GetAllSequences(IEnumerable<char> chars)
        {
            if(chars.Count() == 1)
                return chars.Select(ch => ch.ToString());

            return chars.SelectMany((ch, index) => 
                                    GetAllSequences(chars.RemoveAt(index))
                                    .Select(str => $"{ch}{str}")); 
        }
    }

    static class Extensions
    {
        //Данный метод убирает символ с определенным индексом из последовательности
        //и возвращает новую последовательность без этого символа.
        public static IEnumerable<T> RemoveAt<T>(this IEnumerable<T> sequence, int index)
        {
            return sequence.Take(index).Concat(sequence.Skip(index + 1));
        }
    }
}
