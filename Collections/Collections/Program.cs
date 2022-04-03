using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entity> entities = new List<Entity>()
            {
               new Entity(1,0,"Root entity"),
               new Entity(2, 1, "Child of 1 entity"),
               new Entity(3,1,"Child of 1 entity"),
               new Entity(4, 2,  "Child of 2 entity"),
               new Entity(5, 4, "Child of 4 entity")
            };

            var dict = ListToDictionary(entities);
            foreach (var item in dict)
            {
                Console.Write($"Key = {item.Key}, ");
                foreach (var item2 in item.Value)
                {
                    if (item.Value.Count > 1)
                    {
                        Console.Write($"Value = List [Entity[Id = {item2.Id}]], ");
                    }
                    else
                    {
                        Console.WriteLine($"Value = List [Entity[Id = {item2.Id}]]");
                    }
                }
                if (item.Value.Count > 1) Console.WriteLine();
            }
        }
        private static Dictionary<int, List<Entity>> ListToDictionary(List<Entity> entityListist)
        {
            var list = entityListist;
            entityListist = entityListist.GroupBy(x => x.ParentId)
                .Select(y => y.OrderBy(x => x.Id).First())
                .ToList();
            var dictionary = entityListist.ToDictionary(x => x.ParentId, x => new List<Entity>());
            foreach (var item in list)
            {
                dictionary[item.ParentId].Add(item);
            }
            return dictionary;
        }
    }
}