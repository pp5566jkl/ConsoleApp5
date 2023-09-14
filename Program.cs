using ConsoleApp5;
using System.Collections.Generic;

namespace ConsoleApp5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<drink> drinks = new List<drink>();

            addnewdrink(drinks);

            displaydrinkmenu(drinks);
        }

        private static void displaydrinkmenu(List<drink> mydrinks)
        {

            Console.WriteLine("飲料清單");
            Console.WriteLine("--------------------------");
            int i = 0;
            Console.WriteLine(String.Format("{0,-4}{1,-5}{2,-5}{3,-5}", "編號", "品名", "大小", "價格"));
            foreach (drink drink in mydrinks)
            {
                Console.WriteLine($"{i,-6}{drink.Name,-5}{drink.Size,-5}{drink.Price,5:C0}");
                i++;
            }
            Console.WriteLine("--------------------------");
        }

        private static void addnewdrink(List<drink> drinks)
        {
            drinks.Add(new drink() { Name = "紅茶", Size = "大杯", Price = 50 });
            drinks.Add(new drink() { Name = "紅茶", Size = "小杯", Price = 30 });
            drinks.Add(new drink() { Name = "綠茶", Size = "大杯", Price = 50 });
            drinks.Add(new drink() { Name = "綠茶", Size = "小杯", Price = 30 });
            drinks.Add(new drink() { Name = "咖啡", Size = "大杯", Price = 70 });
            drinks.Add(new drink() { Name = "咖啡", Size = "小杯", Price = 50 });
        }
    }
}