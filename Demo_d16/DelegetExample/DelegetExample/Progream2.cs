using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DelegetExample
{
    internal class Progream2
    {
        public static void Main(string[] args)
        {
            ProductFactory productFactory = new ProductFactory();
            WrapFactory factory = new WrapFactory();


            //Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
            //Func<Product> func2 = new Func<Product>(productFactory.MakeToysCar);

            //Box box1 = factory.WrapProduct(func1);
            //Box box2 = factory.WrapProduct(func2);

            Box box1 = factory.WrapProduct(productFactory.MakePizza);
            Box box2 = factory.WrapProduct(productFactory.MakeToysCar);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
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
        public Box WrapProduct(Func<Product> getProduct)
        {
            Box box = new Box();
            box.Product = getProduct();
            return box;
        }
    }

    class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "pizza";
            return product;
        }

        public Product MakeToysCar()
        {
            Product product = new Product();
            product.Name = "toy car";
            return product;
        }
    }
}
