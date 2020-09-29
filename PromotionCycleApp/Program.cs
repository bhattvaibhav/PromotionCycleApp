using PromotionCycleApp.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionCycleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Comma separated SKU ID ");
            var readItem = Console.ReadLine();

            var skuList = new List<string>();
            if (readItem.IndexOf(",") > 0)
            {
                skuList = readItem.Split(',').ToList();
            }
            else
            {
                skuList.Add(readItem);
            }

            ProductMasterSKUService ss = new ProductMasterSKUService();
            var productList = ss.AddSKU(skuList);
        }
    }
}
