using System;
using System.Collections.Generic;

class Repository<T>
{
    private List<T> items = new List<T>();

    public delegate bool Criteria<T>(T item);

    public void Add(T item)
    {
        items.Add(item);
    }

    public List<T> Find(Criteria<T> criteria)
    {
        List<T> result = new List<T>();

        foreach (T item in items)
        {
            if (criteria(item))
            {
                result.Add(item);
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        Repository<string> stringRepository = new Repository<string>();
        stringRepository.Add("car");
        stringRepository.Add("patrol");
        stringRepository.Add("netbook");

        Repository<string>.Criteria<string> criteria = s => s.Length > 4;

        List<string> result = stringRepository.Find(criteria);

        // Результат
        Console.WriteLine("Words with length greater than 4:");
        foreach (string word in result)
        {
            Console.WriteLine(word);
        }
    }
}
