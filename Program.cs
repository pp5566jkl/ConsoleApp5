using ConsoleApp5;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleApp5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<drink> drinks = new List<drink>();
            List<orderitem> orders = new List<orderitem>();


            //飲料品項
            addnewdrink(drinks);

            //顯示飲料清單
            displaydrinkmenu(drinks);

            //訂購飲料
            placeorder(orders, drinks);

            //計算售價
            CallingConvention(orders, drinks);

        }

        private static void CallingConvention(List<orderitem> myorders, List<drink> mydrinks)
        {
            var total = 0.0;
            string message = "";
            double sellPrice = 0.0;

            foreach (var orderitem in myorders) total += orderitem.subtotal;

            if (total >= 500)
            {
                message = "訂購滿500元以上者8折";
                sellPrice = total * 0.8;
            }
            else if (total >= 300)
            {
                message = "訂購滿300元以上者85折";
                sellPrice = total * 0.85;
            }
            else if (total >= 200)
            {
                message = "訂購滿200元以上者9折";
                sellPrice = total * 0.9;
            }
            else
            {
                message = "訂購未滿200元不打折";
                sellPrice = total;
            }

            Console.WriteLine();
            Console.WriteLine($"您總共訂購{myorders.Count}項飲料，總計{total}元。{message}，合計需付款{sellPrice}元。");
            Console.WriteLine("訂購完成，按任意鍵結束...");
            Console.ReadLine();
        }

        private static void placeorder(List<orderitem> myorders, List<drink> mydrinks)
        {
            Console.WriteLine("開始訂購飲料，按下x鍵後離開...");
            string s;
            int index, quantity, subtotal;
            while (true)
            {
                Console.Write("請輸入您所要的品項編號? ");
                s = Console.ReadLine();
                if (s == "x") break;
                else index = Convert.ToInt32(s);
                Console.Write("請輸入您所要的杯數? ");
                s = Console.ReadLine();
                if (s == "x") break;
                else quantity = Convert.ToInt32(s);
                drink drink = mydrinks[index];
                subtotal = drink.Price * quantity;
                Console.WriteLine($"您訂購{drink.Name}{drink.Size}{quantity}杯，每杯{drink.Price}元，小計{subtotal}元。");
                myorders.Add(new orderitem() { index = index, quantity = quantity, subtotal = subtotal });
            }
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

        private static void addnewdrink(List<drink> mydrinks)
        {
            
            mydrinks.Add(new drink() { Name = "咖啡", Size = "大杯", Price = 60 });
            mydrinks.Add(new drink() { Name = "咖啡", Size = "中杯", Price = 50 });
            mydrinks.Add(new drink() { Name = "紅茶", Size = "大杯", Price = 30 });
            mydrinks.Add(new drink() { Name = "紅茶", Size = "中杯", Price = 20 });
            mydrinks.Add(new drink() { Name = "綠茶", Size = "大杯", Price = 25 });
            mydrinks.Add(new drink() { Name = "綠茶", Size = "中杯", Price = 20 });
        }
    }
}