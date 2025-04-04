using Heritage.Entities;
using System.Globalization;
namespace Heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> listOfProducts = new List<Product>();
            Console.Write("Enter the number of products: ");
            int numberOfProducts = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfProducts; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char typeOfProduct = Char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string productName = Console.ReadLine();

                Console.Write("Price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (typeOfProduct == 'i')
                {
                    Console.Write("Customs fee: ");
                    double productFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    listOfProducts.Add(new ImportedProduct(productName, productPrice, productFee));

                }
                else if (typeOfProduct == 'u')
                {
                    Console.Write("Manufacture date: ");
                    DateTime productManufactureDate = DateTime.Parse(Console.ReadLine());

                    listOfProducts.Add(new UsedProduct(productName, productPrice, productManufactureDate));
                }
                else
                {
                    listOfProducts.Add(new Product(productName, productPrice));
                }
            }
            Console.WriteLine();
            Console.WriteLine("Price TAGS: ");
            foreach (Product product in listOfProducts)
            {
                Console.WriteLine(product.PriceTag());
                
            }
        }
        

    }
}