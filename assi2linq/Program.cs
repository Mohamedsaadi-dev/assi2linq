using Day_01_G03;
using Demo01.Data;

namespace assi2linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Aggregate Operators
            //var products =new List<Product>();  
            //var totalStockByCategory = products
            //    .GroupBy(p => p.Category)
            //    .Select(g => new { Category = g.Key, TotalStock = g.Sum(p => p.UnitsInStock) });
            //var cheapestPriceByCategory = products
            //    .GroupBy(p => p.Category)
            //    .Select(g => new { Category = g.Key, MinPrice = g.Min(p => p.UnitPrice) });
            //var cheapestProductsByCategory = products
            //    .GroupBy(p => p.Category)
            //    .Select(g => new
            //    {
            //        Category = g.Key,
            //        CheapestPrice = g.Min(p => p.UnitPrice),
            //        Products = g.Where(p => p.UnitPrice == g.Min(x => x.UnitPrice)).ToList()
            //    });


            //var mostExpensivePriceByCategory = products
            //    .GroupBy(p => p.Category)
            //    .Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.UnitPrice) });
            //var mostExpensiveProductsByCategory = products
            //    .GroupBy(p => p.Category)
            //    .Select(g => new
            //    {
            //        Category = g.Key,
            //        MaxPrice = g.Max(p => p.UnitPrice),
            //        Products = g.Where(p => p.UnitPrice == g.Max(x => x.UnitPrice)).ToList()
            //    });
            //var averagePriceByCategory = products
            //    .GroupBy(p => p.Category)
            //    .Select(g => new { Category = g.Key, AvgPrice = g.Average(p => p.UnitPrice) });

            //Console.WriteLine("Total Units in Stock by Category:");
            //foreach (var item in totalStockByCategory)
            //    Console.WriteLine($"{item.Category}: {item.TotalStock}");

            //Console.WriteLine("\nCheapest Price by Category:");
            //foreach (var item in cheapestPriceByCategory)
            //    Console.WriteLine($"{item.Category}: {item.MinPrice}");

            //Console.WriteLine("\nProducts with Cheapest Price by Category:");
            //foreach (var item in cheapestProductsByCategory)
            //{
            //    Console.WriteLine($"{item.Category} (Cheapest Price: {item.CheapestPrice}):");
            //    foreach (var p in item.Products)
            //        Console.WriteLine($"  - {p.ProductName}");
            //}

            //Console.WriteLine("\nMost Expensive Price by Category:");
            //foreach (var item in mostExpensivePriceByCategory)
            //    Console.WriteLine($"{item.Category}: {item.MaxPrice}");

            //Console.WriteLine("\nProducts with Most Expensive Price by Category:");
            //foreach (var item in mostExpensiveProductsByCategory)
            //{
            //    Console.WriteLine($"{item.Category} (Most Expensive Price: {item.MaxPrice}):");
            //    foreach (var p in item.Products)
            //        Console.WriteLine($"  - {p.ProductName}");
            //}

            //Console.WriteLine("\nAverage Price by Category:");
            //foreach (var item in averagePriceByCategory)
            //    Console.WriteLine($"{item.Category}: {item.AvgPrice:F2}");
            #endregion
            #region Set Operators

            //var products = new List<Product>();  
            //var customers =new List<Customer>(); 

            //var uniqueCategories = products
            //    .Select(p => p.Category)
            //    .Distinct();
            //var uniqueFirstLetters = products
            //    .Select(p => p.ProductName[0])
            //    .Union(customers.Select(c => c.CustomerName[0]));
            //var commonFirstLetters = products
            //    .Select(p => p.ProductName[0])
            //    .Intersect(customers.Select(c => c.CustomerName[0]));

            //var productOnlyFirstLetters = products
            //    .Select(p => p.ProductName[0])
            //    .Except(customers.Select(c => c.CustomerName[0]));

            //var lastThreeCharacters = products
            //    .Select(p => p.ProductName.Length >= 3 ? p.ProductName[^3..] : p.ProductName)
            //    .Concat(customers.Select(c => c.CustomerName.Length >= 3 ? c.CustomerName[^3..] : c.CustomerName));
            //Console.WriteLine("Unique Categories:");
            //foreach (var category in uniqueCategories)
            //    Console.WriteLine(category);

            //Console.WriteLine("\nUnique First Letters from Products and Customers:");
            //foreach (var letter in uniqueFirstLetters)
            //    Console.WriteLine(letter);

            //Console.WriteLine("\nCommon First Letters from Products and Customers:");
            //foreach (var letter in commonFirstLetters)
            //    Console.WriteLine(letter);

            //Console.WriteLine("\nFirst Letters in Products but not in Customers:");
            //foreach (var letter in productOnlyFirstLetters)
            //    Console.WriteLine(letter);

            //Console.WriteLine("\nLast Three Characters from Customers and Products:");
            //foreach (var chars in lastThreeCharacters)
            //    Console.WriteLine(chars);
            #endregion
            #region Partitioning Operators
            #endregion
            #region Quantifiers
            string[] words = File.ReadAllLines("dictionary_english.txt");
            bool containsEi = words.Any(word => word.Contains("ei", StringComparison.OrdinalIgnoreCase));
            var categoriesWithOutOfStock = ProductsList
    .GroupBy(p => p.Category)
    .Where(g => g.Any(p => p.UnitsInStock == 0))
    .Select(g => new { Category = g.Key, Products = g.ToList() });

            var categoriesAllInStock = ProductsList
    .GroupBy(p => p.Category)
    .Where(g => g.All(p => p.UnitsInStock > 0))
    .Select(g => new { Category = g.Key, Products = g.ToList() });

            #endregion
            #region  Grouping Operators
            List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var groupedNumbers = numbers.GroupBy(n => n % 5);

            foreach (var group in groupedNumbers)
            {
                Console.WriteLine($"Remainder {group.Key}: {string.Join(", ", group)}");
            }
            string[] word = File.ReadAllLines("dictionary_english.txt");

            var groupedWords = words.GroupBy(word => word[0]);

            foreach (var group in groupedWords)
            {
                Console.WriteLine($"Words starting with '{group.Key}': {string.Join(", ", group)}");
                string[] Arr = { "from", "salt", "earn", "last", "near", "form" };

                var groupedAnagrams = Arr.GroupBy(word => new string(word.OrderBy(c => c).ToArray()));

                foreach (var group in groupedAnagrams)
                {
                    Console.WriteLine($"Group: {string.Join(", ", group)}");
                }

            }


            #endregion
        }
    }
}
