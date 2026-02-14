using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class Demo_AssertClass
    {
        static void Main(string[] args)
        {
            Asset asset = new Asset();
            asset.Name = "Asset";

            Stock msft = new Stock()
            {
                Name = "MSFT",
                ShareOwned = 1000
            };

            Asset asset2 = new Stock() { Name = "Apple", ShareOwned = 10002 };
            Stock s2 = msft.Clone();
            //Console.WriteLine(msft.Name);
            //Console.WriteLine(msft.ShareOwned);
            //Display(msft);  //polymorphism多態
            Console.WriteLine(asset.Liability);
            Console.WriteLine(msft.Liability);
            Console.WriteLine(asset2.Liability); //Liability是virtual 方法, 會根據物件的實際型別來決定要呼叫哪個方法
            Console.WriteLine("----------------------");

            Display(msft); //polymorphism多態

            House mansion = new House
            {
                Name = "Mansion",
                Mortgage = 2500000
            };
            //Console.WriteLine(mansion.Name);
            //Console.WriteLine(mansion.Mortgage);
            //Display(mansion);   //polymorphism多態
        }

        public static void Display(Asset asset)
        {
            Console.WriteLine(asset.Name);
            if (asset is Stock s)
            {
                Console.WriteLine(s.ShareOwned);
            }
            else if (asset is House h)
            {
                Console.WriteLine(h.Mortgage);
            }

            ;
        }
    }

    public class Asset
    {
        public string Name;
        public virtual decimal Liability => 0;
        public virtual Asset Clone() => new Asset() { Name = Name };
    }

    public class Stock : Asset
    {
        public long ShareOwned;
        public override decimal Liability => 2;
        public override Stock Clone() => new Stock() { Name = Name, ShareOwned = ShareOwned };
    }

    public class House : Asset
    {
        public decimal Mortgage;
        public override decimal Liability => 3;
    }
}