using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionCycleApp.Infrastructure.Domain
{
    public class ProductSKUMaster
    {
        public string ID { get; set; }
        public int Price { get; set; }

        public ProductSKUMaster(string id, int price)
        {
            this.ID = id;
            this.Price = price;
        }

    }
}
