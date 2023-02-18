using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._02hw
{
    using System;

    class Money
    {
        private int Hrn; // целая часть денег
        private int Kon; // копейки

        public Money(int Hrn, int Kon)
        {
            this.Hrn = Hrn;
            this.Kon = Kon;
        }

        public void SetHrn(int Hrn)
        {
            this.Hrn = Hrn;
        }

        public void SetKon(int Kon)
        {
            this.Kon = Kon;
        }

        public void Print()
        {
            Console.WriteLine("{0}.{1:00}", Hrn, Kon);
        }

        public double ToDouble()
        {
            return Hrn + Kon / 100.0;
        }
    }

    class Product
    {
        private string name;
        private Money price;

        public Product(string name, int Hrn, int Kon)
        {
            this.name = name;
            this.price = new Money(Hrn, Kon);
        }

        public void SetPrice(int Hrn, int Kon)
        {
            price.SetHrn(Hrn);
            price.SetKon(Kon);
        }

        public void Discount(int Hrn, int Kon)
        {
            int totalKon = (int)(price.ToDouble() * 100 - Hrn * 100 - Kon);
            if (totalKon < 0)
            {
                totalKon = 0;
            }
            price.SetHrn(totalKon / 100);
            price.SetKon(totalKon % 100);
        }

        public void Print()
        {
            Console.Write("{0} - Грн ", name);
            price.Print();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Гречка", 80, 50);
            product.Print(); //  80.50
            product.SetPrice(90, 25);
            product.Print(); //  90.25         
            product.Discount(7, 12);
            product.Print(); //  83.13
        }
    }


}
