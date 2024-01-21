using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class GenericList<T>
    {
        private readonly List<T> _list;
        public GenericList()
        {
            _list = new List<T>();
        }
        public void Add(T value)
        {
            _list.Add(value);
        }
        public T this[int index]
        {
            get { return _list[index]; }
        }
    }

    public class GerericDictionary<Tkey, TValue> where Tkey : struct where TValue : class
    {
        private readonly Dictionary<Tkey, TValue> _dic;
        public GerericDictionary()
        {
            _dic = new Dictionary<Tkey, TValue>();
        }
        public void Add(Tkey key, TValue value)
        {
            _dic.Add(key, value);
        }
        public TValue this[Tkey key]
        {
            get { return _dic[key]; }
        }
    }

    // where T : class
    // where T : struct
    // where T : new() => default constructor
    // where T : Book
    public class Compare<T> where T : IComparable
    {
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var book = new Book();
            book.Isbn = "1111";
            book.Title = "Title";

            var gen = new GenericList<Book>();
            gen.Add(book);
            Console.WriteLine($"{gen[0].Isbn} : {gen[0].Title}");
            Console.ReadKey();

            var dic = new GerericDictionary<int, Book>();
            dic.Add(1, book);
            Console.WriteLine($"{dic[1].Isbn} : {dic[1].Title}");
            Console.ReadKey();

            var compare = new Compare<int>();
            var greater = compare.Max(1, 2);
            Console.WriteLine(greater);
            Console.ReadKey();

            var compareString = new Compare<string>();
            var bigString = compareString.Max("a", "b");
            Console.WriteLine(bigString);
            Console.ReadKey();
        }
    }

    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
    }

}
