using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

/*
 * 以接口取代委託,降低耦合
 */
namespace DelegetExample
{

    internal class Progream2
    {
        public static void Main(string[] args)
        {
            IProductFactory pizzaFactory = new PizzaFactory();
            IProductFactory toycarFactory = new ToyCarFactory();
            WrapFactory factory = new WrapFactory();

            Box box1 = factory.WrapProduct(pizzaFactory);
            Box box2 = factory.WrapProduct(toycarFactory);


            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
    }

    interface IProductFactory
    {
        Product Make();
    }

    class PizzaFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "pizza";
            return product;
        }
    }

    class ToyCarFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "toy car";
            return product;
        }
    }

    class Product
    {
        public string Name { get; set; }
    }

    class Box
    {
        public Product Product { get; set; }
    }

    class WrapFactory
    {
        /// <summary>
        /// Wraps the product.
        /// </summary>
        /// <param name="getProduct">將返回值為Product的方法當作參數</param>
        /// <returns></returns>
        public Box WrapProduct(IProductFactory factory)
        {
            Box box = new Box();
            box.Product = factory.Make();
            return box;
        }
    }

}
